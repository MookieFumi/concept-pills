namespace Before.Bookings;

public sealed class Booking
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public DateTimeOffset StartAt { get; init; }

    public BookingStatus Status { get; set; } = BookingStatus.Confirmed;

    public DateTimeOffset? CancelledAt { get; set; }
}
