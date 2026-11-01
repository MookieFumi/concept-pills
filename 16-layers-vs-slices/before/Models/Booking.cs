namespace Before.Models;

public sealed class Booking(Guid id, string roomName, DateTime start)
{
    public Guid Id { get; } = id;

    public string RoomName { get; } = roomName;

    public DateTime Start { get; } = start;

    public bool IsCancelled { get; set; }

    public string? CateringMenu { get; set; }
}
