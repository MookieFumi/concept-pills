using After.Bookings;

var now = new DateTimeOffset(2026, 1, 12, 9, 50, 0, TimeSpan.Zero);

var late = new Booking(now.AddMinutes(10));
try
{
    late.Cancel(now);
}
catch (InvalidOperationException exception)
{
    Console.WriteLine($"Rejected: {exception.Message} Status stays {late.Status}.");
}

var early = new Booking(now.AddHours(2));
early.Cancel(now);
Console.WriteLine($"Status: {early.Status}, cancelled at: {early.CancelledAt:u}");
