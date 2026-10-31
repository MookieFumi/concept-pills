namespace After.Bookings;

// An entity: two bookings are the same booking when they have the same identity, whatever else changes.
public sealed class Booking(Guid id, string roomName, TimeRange range) : IEquatable<Booking>
{
    public Guid Id { get; } = id;

    public string RoomName { get; } = roomName;

    public TimeRange Range { get; } = range;

    public bool IsCancelled { get; private set; }

    public void Cancel()
    {
        IsCancelled = true;
    }

    public bool Equals(Booking? other)
    {
        return other is not null && Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Booking);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
