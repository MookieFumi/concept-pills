namespace After.Reservations;

// The reservations model: it knows about rooms, capacity and cancellation, and nothing about reminders.
public sealed class Booking(string roomName, string organizerId, string title, DateTimeOffset startAt, DateTimeOffset endAt, int attendees)
{
    public Guid Id { get; } = Guid.NewGuid();

    public string RoomName { get; } = roomName;

    public string OrganizerId { get; } = organizerId;

    public string Title { get; } = title;

    public DateTimeOffset StartAt { get; } = startAt;

    public DateTimeOffset EndAt { get; } = endAt;

    public int Attendees { get; } = attendees;

    public BookingStatus Status { get; private set; } = BookingStatus.Confirmed;

    public void Cancel()
    {
        Status = BookingStatus.Cancelled;
    }
}
