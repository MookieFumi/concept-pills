using After.Domain;
using Microsoft.EntityFrameworkCore;

namespace After.Data;

// Command side: loads the aggregate, lets it enforce the rules, saves.
public sealed class BookRoomHandler(BookingsDbContext context)
{
    public async Task<bool> HandleAsync(string roomName, DateTime start, DateTime end)
    {
        var room = await context.Rooms.Include(r => r.Bookings).SingleAsync(r => r.Name == roomName);

        if (!room.Book(start, end))
        {
            return false;
        }

        await context.SaveChangesAsync();
        return true;
    }
}
