using After.Bookings;
using Microsoft.EntityFrameworkCore;

namespace After.Messaging;

// A separate process in real life: reads pending messages and sends them to the broker.
public sealed class OutboxRelay(BookingsDbContext context, FlakyBroker broker)
{
    public async Task RunOnceAsync()
    {
        var pending = await context.Outbox.Where(m => m.ProcessedAt == null).ToListAsync();

        foreach (var message in pending)
        {
            broker.Publish(message.Id);
            message.ProcessedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
        }
    }
}
