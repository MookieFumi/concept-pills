namespace After.Saga;

public sealed record SagaStep(string Name, Action Execute, Action Compensate);
