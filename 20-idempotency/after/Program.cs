using After.Bookings;

var handler = new ReserveHandler();
var key = Guid.NewGuid().ToString();
var command = new ReserveCommand("Lisbon", "Planning");

// The client generates one key per intent and sends it with every attempt.
var first = handler.Handle(key, command);
var second = handler.Handle(key, command);

Console.WriteLine($"First attempt: {first.Outcome}");
Console.WriteLine($"Retry with the same key: {second.Outcome}");
Console.WriteLine($"Same booking returned? {first.BookingId == second.BookingId}");
Console.WriteLine($"Bookings stored: {handler.BookingsStored}");

var other = handler.Handle(key, new ReserveCommand("Berlin", "Retro"));
Console.WriteLine($"Same key, different request: {other.Outcome}");
