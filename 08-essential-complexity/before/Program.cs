using Before.Bookings;

Console.WriteLine(BookingChecker.Check(new() { ["start"] = "2026-01-12T10:00:00Z", ["end"] = "2026-01-12T10:05:00Z" }));
Console.WriteLine(BookingChecker.Check(new() { ["start"] = "2026-01-12T10:00:00Z", ["end"] = "2026-01-12T14:30:00Z" }));
Console.WriteLine(BookingChecker.Check(new() { ["start"] = "2026-01-12T10:00:00Z", ["end"] = "2026-01-12T14:30:00Z", ["legacy"] = true }));
