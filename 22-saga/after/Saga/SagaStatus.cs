namespace After.Saga;

public enum SagaStatus
{
    Pending,
    Confirmed,
    Cancelled,
    CompensationFailed,
}
