using After.Reminders;
using After.Reservations;

var now = new DateTimeOffset(2026, 1, 12, 9, 50, 0, TimeSpan.Zero);
var reservations = new ReservationService();
var soon = reservations.Create("Lisbon", "ana", "Planning", now.AddMinutes(10));
var cancelled = reservations.Create("Madrid", "luis", "Retro", now.AddMinutes(12));
cancelled.Cancel();

new ReminderService(new ReservationsReminderSource(reservations)).RemindBookingsStartingBefore(now, TimeSpan.FromMinutes(15));

Console.WriteLine($"Status after the reminder ran: {soon.Status}");
