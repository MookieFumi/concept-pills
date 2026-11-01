namespace Before.Services;

public sealed class RoomService
{
    public HashSet<Guid> Held { get; } = [];

    public void Hold(Guid bookingId)
    {
        Held.Add(bookingId);
    }
}
