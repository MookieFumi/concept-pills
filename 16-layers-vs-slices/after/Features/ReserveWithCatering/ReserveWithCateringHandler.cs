using After.Data;
using After.Domain;

namespace After.Features.ReserveWithCatering;

// The whole feature lives in this folder: request, handler and its own catering data.
public sealed class ReserveWithCateringHandler(BookingStore store)
{
    private readonly Dictionary<Guid, string> _menus = [];

    public string Handle(ReserveWithCateringRequest request)
    {
        var booking = new Booking(Guid.NewGuid(), request.RoomName, request.Start);
        store.Add(booking);
        _menus[booking.Id] = request.Menu;
        return $"Reserved {booking.RoomName} at {booking.Start:HH:mm} with {request.Menu} catering";
    }
}
