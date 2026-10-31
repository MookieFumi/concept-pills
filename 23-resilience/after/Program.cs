using After.Calendar;

var calendar = new FailingCalendar();
var client = new CalendarClient(calendar);

for (var i = 0; i < 20; i++)
{
    client.TrySync();
}

Console.WriteLine($"Requests: 20. Calls that reached the failing calendar: {calendar.Calls}");
