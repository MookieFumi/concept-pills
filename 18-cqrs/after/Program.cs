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

    foreach (var name in new[] { "Lisbon", "Madrid", "Berlin" })
    {
        var room = new Room(name);

        for (var i = 0; i < 4; i++)
        {
            room.Book(ten.AddHours(i * 2), ten.AddHours(i * 2 + 1));
        }

        seed.Rooms.Add(room);
    }

    seed.SaveChanges();
}

using var context = new BookingsDbContext(options);

var rows = await new RoomOccupancyQuery(context).LoadAsync();

Console.WriteLine($"Rows on screen: {rows.Count}");
Console.WriteLine($"Entities tracked to build them: {context.ChangeTracker.Entries().Count()}");

// The write side still goes through the aggregate and its rules.
var booked = await new BookRoomHandler(context).HandleAsync("Lisbon", ten.AddMinutes(30), ten.AddMinutes(90));
Console.WriteLine($"Booking over an existing one accepted: {booked}");
