namespace Before.Bookings;

// A booking modeled as a record: equality compares every property, so the booking stops being "the same booking"
// as soon as one of them changes.
public sealed record Booking(Guid Id, string RoomName, string Title, DateTimeOffset StartAt)
{
    public bool IsCancelled { get; set; }
}
