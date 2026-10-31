namespace After.Reservations;

public sealed class ReservationService
{
    private readonly List<Booking> _bookings = [];

    public Booking Create(string roomName, string organizerId, string title, DateTimeOffset startAt)
    {
        var booking = new Booking(roomName, organizerId, title, startAt, startAt.AddHours(1), 4);
        _bookings.Add(booking);

        return booking;
    }

    public IReadOnlyList<Booking> ConfirmedStartingBetween(DateTimeOffset from, DateTimeOffset until)
    {
        return [.. _bookings.Where(item => item.Status == BookingStatus.Confirmed && item.StartAt > from && item.StartAt <= until)];
    }
}
