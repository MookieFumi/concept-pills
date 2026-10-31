using After.Domain;
using Microsoft.EntityFrameworkCore;

namespace After.Data;

// A repository that speaks the domain: one question the business asks.
public sealed class RoomAgenda(BookingsDbContext context)
{
    public Task<List<Room>> FindFreeRoomsAsync(DateTime start, DateTime end)
    {
        return context.Rooms
            .Where(r => !r.Bookings.Any(b => b.Start < end && start < b.End))
            .ToListAsync();
    }
}
