using After.Bookings;

var start = new DateTimeOffset(2026, 1, 12, 10, 0, 0, TimeSpan.Zero);
var range = new TimeRange(start, start.AddHours(1));

// Same data, different identity: two bookings.
var first = new Booking(Guid.NewGuid(), "Lisbon", range);
var second = new Booking(Guid.NewGuid(), "Lisbon", range);
Console.WriteLine($"Same data, equal? {first.Equals(second)}");

// Same identity, different state: still the same booking.
var tracked = new Dictionary<Booking, string> { [first] = "tracked" };
first.Cancel();
Console.WriteLine($"Found after cancelling it? {tracked.ContainsKey(first)}");

// A value is compared by what it holds.
Console.WriteLine($"Two equal ranges, equal? {range == new TimeRange(start, start.AddHours(1))}");
