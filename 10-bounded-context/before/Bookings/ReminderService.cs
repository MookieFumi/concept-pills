namespace Before.Bookings;

public sealed class ReminderService(ReservationService reservations)
{
    public void RemindBookingsStartingBefore(DateTimeOffset until)
    {
        foreach (var booking in reservations.Bookings.Where(item => item.StartAt <= until && item.ReminderSentAt is null))
        {
            Console.WriteLine($"Reminder for {booking.OrganizerId}: '{booking.Title}' in {booking.RoomName}");
            booking.ReminderSentAt = until;

            // Nothing stops this service from changing what only the reservations code should decide.
            booking.Status = "Cancelled";
        }
    }
}
