namespace After.Domain;

public sealed class Booking
{
    private Booking()
    {
    }

    internal Booking(DateTime start, DateTime end)
    {
        Id = Guid.NewGuid();
        Start = start;
        End = end;
    }

    public Guid Id { get; private set; }

    public DateTime Start { get; private set; }

    public DateTime End { get; private set; }
}
