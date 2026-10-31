using Before.Calendar;

var calendar = new FailingCalendar();
var endpoint = new BookingEndpoint(new BookingService(new CalendarClient(calendar)));

for (var i = 0; i < 20; i++)
{
    endpoint.Post();
}

Console.WriteLine($"Requests: 20. Calls that reached the failing calendar: {calendar.Calls}");
