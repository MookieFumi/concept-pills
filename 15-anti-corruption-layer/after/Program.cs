using After.Bookings;
using After.Calendar;

var report = new AgendaReport(new CalendarBookingSource(new ExternalCalendarClient()));

Console.WriteLine($"Active bookings: {report.CountActiveBookings()}");
Console.WriteLine($"First booking ends at: {report.FirstEndTime()}");
