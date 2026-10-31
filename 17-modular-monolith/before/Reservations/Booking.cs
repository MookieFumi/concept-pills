namespace Before.Reservations;

public sealed class Booking(Guid id, string roomName)
{
    public Guid Id { get; } = id;

    public string RoomName { get; } = roomName;

    public bool IsCancelled { get; set; }
}
