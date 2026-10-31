namespace After.Data;

public sealed record RoomOccupancyRow(string RoomName, int Bookings, DateTime? LastEnd);
