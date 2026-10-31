namespace After.Bookings;

public interface IBookingRule
{
    /// <returns>The reason the booking breaks the rule, or <see langword="null"/> when it complies.</returns>
    string? Check(BookingCandidate candidate);
}
