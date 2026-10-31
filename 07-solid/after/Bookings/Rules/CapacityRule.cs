namespace After.Bookings.Rules;

public sealed class CapacityRule : IBookingRule
{
    public string? Check(BookingCandidate candidate)
    {
        return candidate.Attendees > candidate.RoomCapacity ? "The room is too small." : null;
    }
}
