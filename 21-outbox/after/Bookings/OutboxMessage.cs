namespace After.Bookings;

public sealed class OutboxMessage(Guid id)
{
    public Guid Id { get; private set; } = id;

    public DateTime? ProcessedAt { get; set; }
}
