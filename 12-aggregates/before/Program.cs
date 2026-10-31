using Before.Bookings;

var store = new BookingStore();
var service = new BookingService(store);
var importer = new CalendarImporter(store);
var ten = new DateTimeOffset(2026, 1, 12, 10, 0, 0, TimeSpan.Zero);

Console.WriteLine($"Service books Lisbon 10:00-11:00: {service.TryBook("Lisbon", "Planning", ten, ten.AddHours(1))}");
Console.WriteLine($"Service books Lisbon 10:30-11:30: {service.TryBook("Lisbon", "Retro", ten.AddMinutes(30), ten.AddMinutes(90))}");

importer.Import("Lisbon", "Imported sync", ten.AddMinutes(30), ten.AddMinutes(90));
Console.WriteLine($"Overlapping bookings after the import: {store.All.Count(b => b.StartAt < ten.AddHours(1) && ten < b.EndAt)}");
