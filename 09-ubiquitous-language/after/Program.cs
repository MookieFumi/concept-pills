using After.Bookings;

// The same word in the conversation, the API, the table and the code.
var service = new BookingService();
var booking = service.Create("Lisbon", new DateTimeOffset(2026, 1, 12, 10, 0, 0, TimeSpan.Zero), new DateTimeOffset(2026, 1, 12, 11, 0, 0, TimeSpan.Zero));
service.Cancel(booking.Id);
