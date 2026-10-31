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

var rows = await new RoomScreen(context).LoadAsync();

Console.WriteLine($"Rows on screen: {rows.Count}");
Console.WriteLine($"Entities tracked to build them: {context.ChangeTracker.Entries().Count()}");
