using Microsoft.EntityFrameworkCore;

namespace After.Data;

// Query side: its own model, shaped for the screen. It never touches the aggregate.
public sealed class RoomOccupancyQuery(BookingsDbContext context)
{
    public Task<List<RoomOccupancyRow>> LoadAsync()
    {
        return context.Rooms
            .AsNoTracking()
            .Select(r => new RoomOccupancyRow(r.Name, r.Bookings.Count, r.Bookings.Max(b => (DateTime?)b.End)))
            .ToListAsync();
    }
}
