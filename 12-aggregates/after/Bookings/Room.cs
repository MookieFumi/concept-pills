namespace After.Bookings;

// The aggregate root: the only way in to the bookings of a room.
public sealed class Room(Guid id, string name)
{
    private const int MaxBookingsPerDay = 3;

    private readonly List<Booking> _bookings = [];

    public Guid Id { get; } = id;

    public string Name { get; } = name;

    public IReadOnlyList<Booking> Bookings => _bookings;

    public BookingResult Book(string title, TimeRange range)
    {
        if (_bookings.Any(b => b.Range.Overlaps(range)))
        {
            return BookingResult.Overlaps;
        }

        if (_bookings.Count(b => b.Range.Start.Date == range.Start.Date) >= MaxBookingsPerDay)
        {
            return BookingResult.DayIsFull;
        }

        _bookings.Add(new Booking(Guid.NewGuid(), title, range));
        return BookingResult.Booked;
    }
}
