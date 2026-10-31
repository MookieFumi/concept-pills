namespace Before.Bookings;

public sealed class Booking
{
    public required string Title { get; set; }

    public DateTimeOffset StartAt { get; set; }

    public List<string> Attendees { get; set; } = [];
}
