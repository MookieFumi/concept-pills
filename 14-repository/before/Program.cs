using Before.Data;
using Before.Domain;
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
#pragma warning disable CA1859
IRepository<Room> rooms = new Repository<Room>(context);
#pragma warning restore CA1859

// "Which room is free?" cannot be asked: load everything and filter in memory.
var all = await rooms.GetAllAsync(nameof(Room.Bookings));
var free = all.Where(r => r.IsFree(ten, ten.AddHours(1))).ToList();
Console.WriteLine($"Rooms loaded to find the free ones: {all.Count}");
Console.WriteLine($"Free rooms: {string.Join(", ", free.Select(r => r.Name))}");

// Update is a no-op here: the context already tracks the entity.
var berlin = free[0];
berlin.Book(ten, ten.AddHours(1));
await rooms.SaveChangesAsync();
Console.WriteLine($"Saved without calling Update: {context.Rooms.AsNoTracking().Include(r => r.Bookings).First(r => r.Name == "Berlin").Bookings.Count == 1}");
