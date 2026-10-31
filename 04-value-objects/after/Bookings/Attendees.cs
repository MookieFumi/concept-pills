namespace After.Bookings;

public readonly record struct Attendees
{
    public Attendees(int value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, 1);
        Value = value;
    }

    public int Value { get; }
}
