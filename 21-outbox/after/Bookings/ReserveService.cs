namespace After.Bookings;

public sealed class ReserveService(BookingsDbContext context)
{
    public async Task ReserveAsync(string title)
    {
        var booking = new Booking(Guid.NewGuid(), title);
        context.Bookings.Add(booking);

        // The message is stored in the same transaction as the booking.
        context.Outbox.Add(new OutboxMessage(booking.Id));

        await context.SaveChangesAsync();
    }
}
