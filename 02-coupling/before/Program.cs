using Before.Bookings;

var handler = new CreateBookingHandler();

// The result depends on when you run it.
handler.Handle(new BookingRequest("Lisbon", "ana@example.com", new DateTimeOffset(2026, 1, 12, 10, 0, 0, TimeSpan.Zero), TimeSpan.FromHours(1)));
