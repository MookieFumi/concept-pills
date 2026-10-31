namespace After.Bookings;

public readonly record struct TimeRange(DateTimeOffset Start, DateTimeOffset End)
{
    public bool Overlaps(TimeRange other)
    {
        return Start < other.End && other.Start < End;
    }
}
