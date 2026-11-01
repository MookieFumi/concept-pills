using After.Data;
using After.Domain;

namespace After.Features.Reserve;

public sealed class ReserveHandler(BookingStore store)
{
    public string Handle(ReserveRequest request)
    {
        var booking = new Booking(Guid.NewGuid(), request.RoomName, request.Start);
        store.Add(booking);
        return $"Reserved {booking.RoomName} at {booking.Start:HH:mm}";
    }
}
