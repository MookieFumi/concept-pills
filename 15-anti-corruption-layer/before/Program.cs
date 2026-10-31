using Before.Bookings;
using Before.Calendar;

var report = new AgendaReport(new ExternalCalendarClient());

Console.WriteLine($"Active bookings: {report.CountActiveBookings()}");
Console.WriteLine($"First booking ends at: {report.FirstEndTime()}");
