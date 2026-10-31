namespace Before.Bookings;

public static class BookingFactory
{
    public static Booking Create(Guid roomId, string organizerId, int attendees, DateTimeOffset startAt, DateTimeOffset endAt)
    {
        return new Booking(roomId, organizerId, attendees, startAt, endAt);
    }
}
