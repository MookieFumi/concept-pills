using Reservations;

namespace Catering;

internal sealed class CateringApi(IReservationsApi reservations) : ICateringApi
{
    public string Order(Guid bookingId, string menu)
    {
        var booking = reservations.Find(bookingId);

        if (booking is null)
        {
            return "No such reservation";
        }

        // Catering can read the summary and decide for itself, but cannot touch the reservation.
        return booking.RoomName == "Berlin"
            ? "Berlin has no kitchen: nothing ordered"
            : $"Ordered {menu} for {booking.RoomName}";
    }
}
