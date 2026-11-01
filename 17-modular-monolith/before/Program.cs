using Before.Catering;
using Before.Reservations;

var store = new BookingStore();
var berlin = new Booking(Guid.NewGuid(), "Berlin");
store.All.Add(berlin);

Console.WriteLine(new CateringService(store).Order(berlin.Id, "vegan"));
Console.WriteLine($"Reservation cancelled: {berlin.IsCancelled}");
