using Reservations;

namespace Catering;

public static class CateringModule
{
    public static ICateringApi Create(IReservationsApi reservations)
    {
        return new CateringApi(reservations);
    }
}
