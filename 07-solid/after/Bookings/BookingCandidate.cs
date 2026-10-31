namespace After.Bookings;

public sealed record BookingCandidate(DateTimeOffset StartAt, DateTimeOffset EndAt, int Attendees, int RoomCapacity);
