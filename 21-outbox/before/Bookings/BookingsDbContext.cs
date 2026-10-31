using Microsoft.EntityFrameworkCore;

namespace Before.Bookings;

public sealed class BookingsDbContext(DbContextOptions<BookingsDbContext> options) : DbContext(options)
{
    public DbSet<Booking> Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>().Property(b => b.Id).ValueGeneratedNever();
    }
}
