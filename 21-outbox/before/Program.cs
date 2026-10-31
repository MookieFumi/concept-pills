using Before.Bookings;
using Before.Messaging;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

using var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();
var options = new DbContextOptionsBuilder<BookingsDbContext>().UseSqlite(connection).Options;

using var context = new BookingsDbContext(options);
context.Database.EnsureCreated();

var broker = new FlakyBroker { IsDown = true };

try
{
    await new ReserveService(context, broker).ReserveAsync("Planning");
}
catch (InvalidOperationException)
{
    Console.WriteLine("The request failed: the broker was down.");
}

Console.WriteLine($"Bookings in the database: {await context.Bookings.CountAsync()}");
Console.WriteLine($"Messages the other services received: {broker.Received.Count}");
