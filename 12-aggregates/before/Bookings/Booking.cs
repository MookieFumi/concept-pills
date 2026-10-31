namespace Before.Bookings;

public sealed record Booking(Guid Id, string RoomName, string Title, DateTimeOffset StartAt, DateTimeOffset EndAt);
