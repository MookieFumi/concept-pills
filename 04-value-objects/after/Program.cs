using After.Bookings;

var start = new DateTimeOffset(2026, 1, 12, 10, 0, 0, TimeSpan.Zero);

var booking = new Booking(Guid.NewGuid(), new OrganizerId("ana"), new Attendees(4), new TimeRange(start, start.AddHours(1)));
Console.WriteLine($"Valid booking: {booking.Organizer.Value}, {booking.Attendees.Value} people, {booking.Range.Duration}");

// The invalid cases can no longer be built.
try
{
    _ = new TimeRange(start.AddHours(1), start);
}
catch (ArgumentException exception)
{
    Console.WriteLine($"Rejected: {exception.Message}");
}

try
{
    _ = new Attendees(-3);
}
catch (ArgumentOutOfRangeException)
{
    Console.WriteLine("Rejected: attendees must be at least 1.");
}
