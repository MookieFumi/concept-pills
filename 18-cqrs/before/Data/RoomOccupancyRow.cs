namespace Before.Data;

public sealed record RoomOccupancyRow(string RoomName, int Bookings, DateTime? LastEnd);
