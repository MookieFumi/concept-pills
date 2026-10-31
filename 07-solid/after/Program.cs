using After.Bookings;
using After.Bookings.Rules;

// The validator depends on the abstraction. Adding a rule is adding a class and one line here.
var validator = new BookingValidator([new MinimumDurationRule(), new MaximumDurationRule(), new WeekdayRule(), new CapacityRule()]);

var saturday = new DateTimeOffset(2026, 1, 17, 10, 0, 0, TimeSpan.Zero);
var candidate = new BookingCandidate(saturday, saturday.AddHours(6), 20, 12);

foreach (var violation in validator.Validate(candidate))
{
    Console.WriteLine(violation);
}
