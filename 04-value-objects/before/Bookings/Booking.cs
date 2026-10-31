namespace Before.Bookings;

public sealed record Booking(Guid RoomId, string OrganizerId, int Attendees, DateTimeOffset StartAt, DateTimeOffset EndAt);
