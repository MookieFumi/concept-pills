namespace After.Domain;

public sealed class Room
{
    private readonly List<Booking> _bookings = [];

    private Room()
    {
    }

    public Room(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; } = "";

    public IReadOnlyList<Booking> Bookings => _bookings;

    public bool IsFree(DateTime start, DateTime end)
    {
        return !_bookings.Any(b => b.Start < end && start < b.End);
    }

    public bool Book(DateTime start, DateTime end)
    {
        if (!IsFree(start, end))
        {
            return false;
        }

        _bookings.Add(new Booking(start, end));
        return true;
    }
}
