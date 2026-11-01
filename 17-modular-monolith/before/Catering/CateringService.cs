using Before.Reservations;

namespace Before.Catering;

// Nothing stops this module from reaching into the reservations' internals.
public sealed class CateringService(BookingStore bookings)
{
    public string Order(Guid bookingId, string menu)
    {
        var booking = bookings.All.Single(b => b.Id == bookingId);

        if (booking.RoomName == "Berlin")
        {
            // A shortcut that crosses the boundary: catering decides a reservation's fate.
            booking.IsCancelled = true;
            return $"Berlin has no kitchen: reservation for {booking.RoomName} cancelled by Catering";
        }

        return $"Ordered {menu} for {booking.RoomName}";
    }
}
