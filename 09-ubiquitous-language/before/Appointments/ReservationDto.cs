namespace Before.Appointments;

// The API calls it a reservation.
public sealed record ReservationDto(string RoomName, DateTimeOffset From, DateTimeOffset To);
