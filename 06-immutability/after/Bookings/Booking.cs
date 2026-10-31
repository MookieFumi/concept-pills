using System.Collections.Immutable;

namespace After.Bookings;

public sealed record Booking(string Title, DateTimeOffset StartAt, ImmutableArray<string> Attendees)
{
    public Booking Reschedule(DateTimeOffset newStart)
    {
        return this with { StartAt = newStart };
    }

    public Booking AddAttendee(string attendee)
    {
        return this with { Attendees = Attendees.Add(attendee) };
    }
}
