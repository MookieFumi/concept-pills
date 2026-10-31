namespace After.Bookings;

public sealed class Booking(DateTimeOffset startAt)
{
    public static readonly TimeSpan CancellationNotice = TimeSpan.FromMinutes(15);

    public Guid Id { get; } = Guid.NewGuid();

    public DateTimeOffset StartAt { get; } = startAt;

    public BookingStatus Status { get; private set; } = BookingStatus.Confirmed;

    public DateTimeOffset? CancelledAt { get; private set; }

    public void Cancel(DateTimeOffset now)
    {
        if (Status == BookingStatus.Cancelled)
        {
            throw new InvalidOperationException("The booking is already cancelled.");
        }

        if (StartAt - now < CancellationNotice)
        {
            throw new InvalidOperationException("Too late to cancel.");
        }

        Status = BookingStatus.Cancelled;
        CancelledAt = now;
    }
}
