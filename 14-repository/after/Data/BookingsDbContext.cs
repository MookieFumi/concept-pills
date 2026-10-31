using After.Domain;
using Microsoft.EntityFrameworkCore;

namespace After.Data;

public sealed class BookingsDbContext(DbContextOptions<BookingsDbContext> options) : DbContext(options)
{
    public DbSet<Room> Rooms => Set<Room>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ids are assigned by the domain, so EF must treat unknown keys as new rows.
        modelBuilder.Entity<Room>().Property(r => r.Id).ValueGeneratedNever();
        modelBuilder.Entity<Booking>().Property(b => b.Id).ValueGeneratedNever();
    }
}
