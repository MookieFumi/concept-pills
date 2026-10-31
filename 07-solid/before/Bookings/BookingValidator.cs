namespace Before.Bookings;

// Every new rule means opening this class, adding another branch and re-testing all the others.
public sealed class BookingValidator
{
    public List<string> Validate(BookingCandidate candidate)
    {
        var violations = new List<string>();
        var duration = candidate.EndAt - candidate.StartAt;

        if (duration < TimeSpan.FromMinutes(15))
        {
            violations.Add("A booking lasts at least 15 minutes.");
        }

        if (duration > TimeSpan.FromHours(4))
        {
            violations.Add("A booking lasts at most 4 hours.");
        }

        if (candidate.StartAt.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
        {
            violations.Add("Rooms are booked Monday to Friday.");
        }

        if (candidate.Attendees > candidate.RoomCapacity)
        {
            violations.Add("The room is too small.");
        }

        return violations;
    }
}
