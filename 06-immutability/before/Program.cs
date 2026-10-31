using Before.Bookings;

var id = Guid.NewGuid();
var start = new DateTimeOffset(2026, 1, 12, 10, 0, 0, TimeSpan.Zero);
var cache = new BookingCache();
cache.Add(id, new Booking { Title = "Planning", StartAt = start, Attendees = ["ana"] });

// One caller reschedules "its" booking...
var forReschedule = cache.Get(id);
forReschedule.StartAt = start.AddHours(3);
forReschedule.Attendees.Add("luis");

// ...and a different caller, which only wanted to read, sees the change.
var forReminder = cache.Get(id);
Console.WriteLine($"Reminder reads: {forReminder.StartAt:HH:mm}, {string.Join(",", forReminder.Attendees)}");
