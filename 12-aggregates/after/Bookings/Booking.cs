namespace After.Bookings;

// Part of the Room aggregate: it is created only by Room.
public sealed class Booking
{
    internal Booking(Guid id, string title, TimeRange range)
    {
        Id = id;
        Title = title;
        Range = range;
    }

    public Guid Id { get; }

    public string Title { get; }

    public TimeRange Range { get; }
}
