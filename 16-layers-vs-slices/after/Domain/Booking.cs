namespace After.Domain;

public sealed class Booking(Guid id, string roomName, DateTime start)
{
    public Guid Id { get; } = id;

    public string RoomName { get; } = roomName;

    public DateTime Start { get; } = start;

    public bool IsCancelled { get; private set; }

    public void Cancel()
    {
        IsCancelled = true;
    }
}
