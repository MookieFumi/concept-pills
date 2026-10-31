using Before.Bookings;

var start = new DateTimeOffset(2026, 1, 12, 10, 0, 0, TimeSpan.Zero);
var end = start.AddHours(1);

// The end comes before the start, the organizer is empty and nobody is attending. It all compiles and it all works.
var booking = BookingFactory.Create(Guid.NewGuid(), "", -3, end, start);

Console.WriteLine($"Organizer: '{booking.OrganizerId}', attendees: {booking.Attendees}, duration: {booking.EndAt - booking.StartAt}");
