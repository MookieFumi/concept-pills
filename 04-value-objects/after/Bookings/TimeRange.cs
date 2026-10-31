namespace After.Bookings;

/// <summary>A half-open interval: it includes <see cref="Start"/> and excludes <see cref="End"/>.</summary>
public readonly record struct TimeRange
{
    public TimeRange(DateTimeOffset start, DateTimeOffset end)
    {
        if (end <= start)
        {
            throw new ArgumentException("The end must be after the start.", nameof(end));
        }

        Start = start;
        End = end;
    }

    public DateTimeOffset Start { get; }

    public DateTimeOffset End { get; }

    public TimeSpan Duration => End - Start;
}
