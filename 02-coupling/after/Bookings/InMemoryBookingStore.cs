namespace After.Bookings;

public sealed class InMemoryBookingStore : IBookingStore
{
    private readonly List<BookingRequest> _bookings = [];

    public int Count => _bookings.Count;

    public void Insert(BookingRequest request)
    {
        _bookings.Add(request);
    }
}
