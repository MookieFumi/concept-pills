namespace Reservations;

internal sealed class ReservationsApi : IReservationsApi
{
    private readonly Dictionary<Guid, Booking> _bookings = [];

    public Guid Reserve(string roomName)
    {
        var booking = new Booking(Guid.NewGuid(), roomName);
        _bookings[booking.Id] = booking;
        return booking.Id;
    }

    public BookingSummary? Find(Guid id)
    {
        return _bookings.TryGetValue(id, out var b) ? new BookingSummary(b.Id, b.RoomName, b.IsCancelled) : null;
    }
}
