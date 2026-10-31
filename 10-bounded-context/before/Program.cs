using Before.Bookings;

var now = new DateTimeOffset(2026, 1, 12, 9, 50, 0, TimeSpan.Zero);
var reservations = new ReservationService();
var booking = reservations.Create("Lisbon", "ana", "Planning", now.AddMinutes(10));

new ReminderService(reservations).RemindBookingsStartingBefore(now.AddMinutes(15));

Console.WriteLine($"Status after the reminder ran: {booking.Status}");
