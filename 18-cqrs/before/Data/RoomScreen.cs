using Before.Domain;
using Microsoft.EntityFrameworkCore;

namespace Before.Data;

// The screen reuses the write model: it loads whole aggregates just to count and format them.
public sealed class RoomScreen(BookingsDbContext context)
{
    public async Task<List<RoomOccupancyRow>> LoadAsync()
    {
        var rooms = await context.Rooms.Include(r => r.Bookings).ToListAsync();

        return rooms
            .Select(r => new RoomOccupancyRow(r.Name, r.Bookings.Count, r.Bookings.Max(b => (DateTime?)b.End)))
            .ToList();
    }
}
