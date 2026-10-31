using After.Bookings;

var start = new DateTimeOffset(2026, 1, 12, 10, 0, 0, TimeSpan.Zero);
var original = new Booking("Planning", start, ["ana"]);

// Every change returns a new value. Whoever holds the original keeps what they read.
var changed = original.Reschedule(start.AddHours(3)).AddAttendee("luis");

Console.WriteLine($"Original: {original.StartAt:HH:mm}, {string.Join(",", original.Attendees)}");
Console.WriteLine($"Changed:  {changed.StartAt:HH:mm}, {string.Join(",", changed.Attendees)}");
