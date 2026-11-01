using Before.Controllers;
using Before.Dtos;
using Before.Repositories;
using Before.Services;

var controller = new BookingsController(new BookingService(new InMemoryBookingRepository()));
var ten = new DateTime(2026, 1, 12, 10, 0, 0, DateTimeKind.Utc);

Console.WriteLine(controller.Reserve(new ReserveRequest("Lisbon", ten)));
Console.WriteLine(controller.ReserveWithCatering(new ReserveWithCateringRequest("Berlin", ten, "vegan")));
