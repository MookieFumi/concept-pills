namespace After.Bookings;

public sealed record BookingRequest(string RoomName, string OrganizerEmail, DateTimeOffset StartAt, TimeSpan Duration);
