namespace After.Bookings;

public sealed class Booking(Guid id, string title)
{
    public Guid Id { get; private set; } = id;

    public string Title { get; private set; } = title;
}
