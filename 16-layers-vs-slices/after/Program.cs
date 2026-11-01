using After.Data;
using After.Features.Reserve;
using After.Features.ReserveWithCatering;

var store = new BookingStore();
var ten = new DateTime(2026, 1, 12, 10, 0, 0, DateTimeKind.Utc);

Console.WriteLine(new ReserveHandler(store).Handle(new ReserveRequest("Lisbon", ten)));
Console.WriteLine(new ReserveWithCateringHandler(store).Handle(new ReserveWithCateringRequest("Berlin", ten, "vegan")));
