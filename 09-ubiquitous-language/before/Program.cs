using Before.Appointments;

// The business says "cancel the booking". The code says reservation, meeting, appointment and remove.
var service = new MeetingService();
var id = service.Add(new ReservationDto("Lisbon", new DateTimeOffset(2026, 1, 12, 10, 0, 0, TimeSpan.Zero), new DateTimeOffset(2026, 1, 12, 11, 0, 0, TimeSpan.Zero)));
service.Remove(id);
