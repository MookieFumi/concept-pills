using After.Bookings;

var lisbon = new Room(Guid.NewGuid(), "Lisbon");
var importer = new CalendarImporter();
var ten = new DateTimeOffset(2026, 1, 12, 10, 0, 0, TimeSpan.Zero);

Console.WriteLine($"Room books 10:00-11:00: {lisbon.Book("Planning", new TimeRange(ten, ten.AddHours(1)))}");
Console.WriteLine($"Room books 10:30-11:30: {lisbon.Book("Retro", new TimeRange(ten.AddMinutes(30), ten.AddMinutes(90)))}");
Console.WriteLine($"Importer books 10:30-11:30: {importer.Import(lisbon, "Imported sync", new TimeRange(ten.AddMinutes(30), ten.AddMinutes(90)))}");
Console.WriteLine($"Bookings in Lisbon: {lisbon.Bookings.Count}");
