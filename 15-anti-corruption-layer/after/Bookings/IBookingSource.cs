namespace After.Bookings;

// Defined in our domain, in our words. The domain never sees ExternalEvent.
public interface IBookingSource
{
    IReadOnlyList<Booking> GetBookings();
}
