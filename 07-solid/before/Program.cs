using Before.Bookings;

var saturday = new DateTimeOffset(2026, 1, 17, 10, 0, 0, TimeSpan.Zero);
var candidate = new BookingCandidate(saturday, saturday.AddHours(6), 20, 12);

foreach (var violation in new BookingValidator().Validate(candidate))
{
    Console.WriteLine(violation);
}
