using System.Reflection;
using Catering;
using Reservations;

var reservations = ReservationsModule.Create();
var catering = CateringModule.Create(reservations);

var berlin = reservations.Reserve("Berlin");
Console.WriteLine(catering.Order(berlin, "vegan"));
Console.WriteLine($"Reservation cancelled: {reservations.Find(berlin)!.IsCancelled}");

foreach (var module in new[] { typeof(IReservationsApi).Assembly, typeof(ICateringApi).Assembly })
{
    var publicTypes = module.GetExportedTypes().Select(t => t.Name).Order();
    Console.WriteLine($"{module.GetName().Name} exposes: {string.Join(", ", publicTypes)}");
}
