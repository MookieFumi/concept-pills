using Before.Models;

namespace Before.Repositories;

public sealed class InMemoryBookingRepository : IBookingRepository
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
