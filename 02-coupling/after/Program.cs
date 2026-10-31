using After.Bookings;

var store = new InMemoryBookingStore();
var clock = new FixedClock(new DateTimeOffset(2026, 1, 12, 9, 0, 0, TimeSpan.Zero));
var handler = new CreateBookingHandler(store, new ConsoleNotifier(), clock);

var past = new BookingRequest("Lisbon", "ana@example.com", new DateTimeOffset(2026, 1, 12, 8, 0, 0, TimeSpan.Zero), TimeSpan.FromHours(1));
var future = past with { StartAt = new DateTimeOffset(2026, 1, 12, 10, 0, 0, TimeSpan.Zero) };

Console.WriteLine($"Past booking accepted: {handler.Handle(past)}");
Console.WriteLine($"Future booking accepted: {handler.Handle(future)}");
Console.WriteLine($"Stored: {store.Count}");
