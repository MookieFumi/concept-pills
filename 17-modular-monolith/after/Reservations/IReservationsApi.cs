namespace Reservations;

// The public surface of the module.
public interface IReservationsApi
{
    Guid Reserve(string roomName);

    BookingSummary? Find(Guid id);
}
