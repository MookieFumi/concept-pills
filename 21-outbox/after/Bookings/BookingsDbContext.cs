using Microsoft.EntityFrameworkCore;

namespace After.Bookings;

public sealed class BookingsDbContext(DbContextOptions<BookingsDbContext> options) : DbContext(options)
{
    public DbSet<Booking> Bookings => Set<Booking>();

    public DbSet<OutboxMessage> Outbox => Set<OutboxMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>().Property(b => b.Id).ValueGeneratedNever();
        modelBuilder.Entity<OutboxMessage>().Property(m => m.Id).ValueGeneratedNever();
    }
}
