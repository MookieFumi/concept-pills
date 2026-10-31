namespace After.Bookings;

public sealed record Booking(string Title, DateTimeOffset StartAt, IReadOnlyList<string> Attendees)
{
    public Booking Reschedule(DateTimeOffset newStart)
    {
        return this with { StartAt = newStart };
    }

    public Booking AddAttendee(string attendee)
    {
        return this with { Attendees = [.. Attendees, attendee] };
    }
}
