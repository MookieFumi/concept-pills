using Before.Dtos;
using Before.Services;

namespace Before.Controllers;

public sealed class BookingsController(IBookingService service)
{
    public string Reserve(ReserveRequest request)
    {
        var booking = service.Reserve(request);
        return $"Reserved {booking.RoomName} at {booking.Start:HH:mm}";
    }

    public string ReserveWithCatering(ReserveWithCateringRequest request)
    {
        var booking = service.ReserveWithCatering(request);
        return $"Reserved {booking.RoomName} at {booking.Start:HH:mm} with {booking.CateringMenu} catering";
    }
}
