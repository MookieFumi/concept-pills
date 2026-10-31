namespace After.Bookings;

public sealed class Booking(string roomName, DateTimeOffset startAt, DateTimeOffset endAt)
{
    public Guid Id { get; } = Guid.NewGuid();

    public string RoomName { get; } = roomName;

    public DateTimeOffset StartAt { get; } = startAt;

    public DateTimeOffset EndAt { get; } = endAt;

    public BookingStatus Status { get; private set; } = BookingStatus.Confirmed;

    public void Cancel()
    {
        Status = BookingStatus.Cancelled;
    }
}
