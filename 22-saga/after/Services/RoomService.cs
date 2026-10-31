namespace After.Services;

public sealed class RoomService
{
    public HashSet<Guid> Held { get; } = [];

    public bool FailOnRelease { get; set; }

    public void Hold(Guid bookingId)
    {
        Held.Add(bookingId);
    }

    public void Release(Guid bookingId)
    {
        if (FailOnRelease)
        {
            throw new InvalidOperationException("The room service is unreachable.");
        }

        Held.Remove(bookingId);
    }
}
