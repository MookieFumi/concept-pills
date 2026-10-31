namespace After.Saga;

// An orchestrator: runs the local transactions in order and undoes the finished ones if a step fails.
public sealed class BookingSaga(IReadOnlyList<SagaStep> steps)
{
    public SagaStatus Status { get; private set; } = SagaStatus.Pending;

    public void Run()
    {
        var completed = new Stack<SagaStep>();

        try
        {
            foreach (var step in steps)
            {
                step.Execute();
                completed.Push(step);
            }

            Status = SagaStatus.Confirmed;
        }
        catch (InvalidOperationException)
        {
            Compensate(completed);
        }
    }

    private void Compensate(Stack<SagaStep> completed)
    {
        try
        {
            while (completed.Count > 0)
            {
                completed.Pop().Compensate();
            }

            Status = SagaStatus.Cancelled;
        }
        catch (InvalidOperationException)
        {
            // A compensation is another business transaction: it can fail too, and somebody has to know.
            Status = SagaStatus.CompensationFailed;
        }
    }
}
