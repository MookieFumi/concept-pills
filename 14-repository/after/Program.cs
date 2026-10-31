using After.Data;
using After.Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

using var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();
var options = new DbContextOptionsBuilder<BookingsDbContext>().UseSqlite(connection).Options;
var ten = new DateTime(2026, 1, 12, 10, 0, 0, DateTimeKind.Utc);

using (var seed = new BookingsDbContext(options))
{
    seed.Database.EnsureCreated();
    var lisbon = new Room("Lisbon");
    var madrid = new Room("Madrid");
    lisbon.Book(ten, ten.AddHours(1));
    madrid.Book(ten.AddMinutes(30), ten.AddMinutes(90));
    seed.Rooms.AddRange(lisbon, madrid, new Room("Berlin"));
    seed.SaveChanges();
}

using var context = new BookingsDbContext(options);

// The business question has its own method, and the filter runs in the database.
var free = await new RoomAgenda(context).FindFreeRoomsAsync(ten, ten.AddHours(1));
Console.WriteLine($"Rooms loaded to find the free ones: {free.Count}");
Console.WriteLine($"Free rooms: {string.Join(", ", free.Select(r => r.Name))}");

// Loading and saving one aggregate needs no wrapper: DbContext is already unit of work + repository.
var berlin = await context.Rooms.Include(r => r.Bookings).SingleAsync(r => r.Name == "Berlin");
berlin.Book(ten, ten.AddHours(1));
await context.SaveChangesAsync();
Console.WriteLine($"Berlin bookings saved: {context.Rooms.AsNoTracking().Include(r => r.Bookings).Single(r => r.Name == "Berlin").Bookings.Count}");
