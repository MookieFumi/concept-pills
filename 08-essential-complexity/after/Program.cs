using System.Globalization;

using After.Bookings;

var start = DateTimeOffset.Parse("2026-01-12T10:00:00Z", CultureInfo.InvariantCulture);

Console.WriteLine(BookingDuration.Check(start, start.AddMinutes(5)) ?? "OK");
Console.WriteLine(BookingDuration.Check(start, start.AddMinutes(270)) ?? "OK");
Console.WriteLine(BookingDuration.Check(start, start.AddHours(1)) ?? "OK");
