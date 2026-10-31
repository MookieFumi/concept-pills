namespace After.Bookings;

public interface IClock
{
    DateTimeOffset Now { get; }
}
