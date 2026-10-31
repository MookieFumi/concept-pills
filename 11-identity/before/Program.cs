using Before.Bookings;

var start = new DateTimeOffset(2026, 1, 12, 10, 0, 0, TimeSpan.Zero);

// Two different bookings with the same data are considered the same one.
var first = new Booking(Guid.Empty, "Lisbon", "Planning", start);
var second = new Booking(Guid.Empty, "Lisbon", "Planning", start);
Console.WriteLine($"Same data, equal? {first == second}");

// The same booking, after changing it, is no longer found.
var cancelled = new Dictionary<Booking, string>();
var booking = new Booking(Guid.NewGuid(), "Madrid", "Retro", start);
cancelled[booking] = "tracked";
booking.IsCancelled = true;
Console.WriteLine($"Found after cancelling it? {cancelled.ContainsKey(booking)}");
