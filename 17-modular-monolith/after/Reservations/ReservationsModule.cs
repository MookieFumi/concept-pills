namespace Reservations;

public static class ReservationsModule
{
    public static IReservationsApi Create()
    {
        return new ReservationsApi();
    }
}
