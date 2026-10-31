namespace After.Bookings;

public readonly record struct OrganizerId
{
    public OrganizerId(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        Value = value;
    }

    public string Value { get; }
}
