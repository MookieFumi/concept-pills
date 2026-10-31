using Before.Bookings;

var services = new ConsoleServices();
var booking = new Booking(Guid.NewGuid(), "Planning");

Console.WriteLine("Cancel needs three collaborators just to flip one flag:");
booking.Cancel(services, services, services);
Console.WriteLine($"Cancelled: {booking.IsCancelled}");
