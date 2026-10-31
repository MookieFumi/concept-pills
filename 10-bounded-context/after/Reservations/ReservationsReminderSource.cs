using After.Reminders;

namespace After.Reservations;

// The translation lives at the boundary: this is the only place that knows both models.
public sealed class ReservationsReminderSource(ReservationService reservations) : IReminderSource
{
    public IReadOnlyList<DueReminder> StartingBetween(DateTimeOffset from, DateTimeOffset until)
    {
        return [.. reservations.ConfirmedStartingBetween(from, until)
            .Select(booking => new DueReminder(booking.Id, booking.OrganizerId, booking.Title, booking.RoomName, booking.StartAt))];
    }
}
