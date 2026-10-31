namespace Reservations;

// What other modules are allowed to know about a booking.
public sealed record BookingSummary(Guid Id, string RoomName, bool IsCancelled);
