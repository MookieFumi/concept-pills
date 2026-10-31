namespace After.Bookings;

public sealed record Booking(Guid RoomId, OrganizerId Organizer, Attendees Attendees, TimeRange Range);
