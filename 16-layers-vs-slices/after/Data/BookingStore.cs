using After.Domain;

namespace After.Data;

public sealed class BookingStore
{
    private readonly Dictionary<Guid, Booking> _bookings = [];

    public void Add(Booking booking)
    {
        _bookings[booking.Id] = booking;
    }

    public Booking? Find(Guid id)
    {
        return _bookings.GetValueOrDefault(id);
    }
}
