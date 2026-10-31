namespace Before.Bookings;

public sealed class BookingPolicy
{
    public static readonly TimeSpan CancellationNotice = TimeSpan.FromMinutes(15);

    public string? CanCancel(Booking booking, DateTimeOffset now)
    {
        if (booking.Status == BookingStatus.Cancelled)
        {
            return "The booking is already cancelled.";
        }

        return booking.StartAt - now < CancellationNotice ? "Too late to cancel." : null;
    }
}
