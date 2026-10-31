namespace Before.Bookings;

// A plain collection: it accepts whatever it is given.
public sealed class BookingStore
{
    private readonly List<Booking> _bookings = [];

    public List<Booking> All => _bookings;
}
