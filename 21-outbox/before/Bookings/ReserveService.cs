using Before.Messaging;

namespace Before.Bookings;

public sealed class ReserveService(BookingsDbContext context, FlakyBroker broker)
{
    public async Task ReserveAsync(string title)
    {
        var booking = new Booking(Guid.NewGuid(), title);
        context.Bookings.Add(booking);
        await context.SaveChangesAsync();

        // Two systems, two writes, no shared transaction.
        broker.Publish(booking.Id);
    }
}
