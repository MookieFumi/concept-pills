namespace After.Bookings.Rules;

public sealed class WeekdayRule : IBookingRule
{
    public string? Check(BookingCandidate candidate)
    {
        return candidate.StartAt.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday ? "Rooms are booked Monday to Friday." : null;
    }
}
