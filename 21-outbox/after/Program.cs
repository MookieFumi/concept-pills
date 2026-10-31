using After.Bookings;
using After.Messaging;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

using var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();
var options = new DbContextOptionsBuilder<BookingsDbContext>().UseSqlite(connection).Options;

using var context = new BookingsDbContext(options);
context.Database.EnsureCreated();

var broker = new FlakyBroker { IsDown = true };
var relay = new OutboxRelay(context, broker);

await new ReserveService(context).ReserveAsync("Planning");
Console.WriteLine($"Bookings in the database: {await context.Bookings.CountAsync()}");
Console.WriteLine($"Pending in the outbox: {await context.Outbox.CountAsync(m => m.ProcessedAt == null)}");

// The broker is down: the relay fails, the message stays pending.
await Attempt(relay);
Console.WriteLine($"Pending after the broker failure: {await context.Outbox.CountAsync(m => m.ProcessedAt == null)}");

// The broker comes back but loses the acknowledgement: delivered, yet still pending.
broker.IsDown = false;
broker.LoseNextAck = true;
await Attempt(relay);

// The relay retries and delivers the same message again.
await relay.RunOnceAsync();
Console.WriteLine($"Copies received by the broker: {broker.Received.Count}");

var consumer = new IdempotentConsumer();

foreach (var id in broker.Received)
{
    consumer.Handle(id);
}

Console.WriteLine($"Messages the consumer processed: {consumer.ProcessedCount}");

static async Task Attempt(OutboxRelay relay)
{
    try
    {
        await relay.RunOnceAsync();
    }
    catch (Exception e) when (e is InvalidOperationException or TimeoutException)
    {
        Console.WriteLine($"Relay failed: {e.Message}");
    }
}
