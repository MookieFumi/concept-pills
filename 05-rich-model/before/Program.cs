using Before.Bookings;

var now = new DateTimeOffset(2026, 1, 12, 9, 50, 0, TimeSpan.Zero);
var booking = new Booking { StartAt = now.AddMinutes(10) };

Console.WriteLine($"Policy says: {new BookingPolicy().CanCancel(booking, now)}");

// Nothing forces anyone to ask the policy first. The setter accepts the change anyway.
booking.Status = BookingStatus.Cancelled;
Console.WriteLine($"Status: {booking.Status}, cancelled at: {booking.CancelledAt?.ToString("u") ?? "nobody knows"}");
