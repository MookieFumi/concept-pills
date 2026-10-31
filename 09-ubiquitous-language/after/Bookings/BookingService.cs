namespace After.Bookings;

public sealed class BookingService
{
    private readonly List<Booking> _bookings = [];

    public Booking Create(string roomName, DateTimeOffset startAt, DateTimeOffset endAt)
    {
        var booking = new Booking(roomName, startAt, endAt);
        _bookings.Add(booking);
        Console.WriteLine($"Booking {booking.Id:N} created in {booking.RoomName}");

        return booking;
    }

    public void Cancel(Guid bookingId)
    {
        var booking = _bookings.Single(item => item.Id == bookingId);
        booking.Cancel();
        Console.WriteLine($"Booking {booking.Id:N} cancelled (status={booking.Status})");
    }
}
