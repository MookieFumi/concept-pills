namespace Before.Bookings;

public sealed class BookingCache
{
    private readonly Dictionary<Guid, Booking> _items = [];

    public void Add(Guid id, Booking booking)
    {
        _items[id] = booking;
    }

    public Booking Get(Guid id)
    {
        return _items[id];
    }
}
