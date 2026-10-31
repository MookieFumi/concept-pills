namespace After.Bookings;

public sealed record ReserveResult(ReserveOutcome Outcome, Guid? BookingId);
