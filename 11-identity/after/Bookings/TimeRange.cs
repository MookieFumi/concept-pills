namespace After.Bookings;

// A value: two ranges with the same start and end are the same range.
public readonly record struct TimeRange(DateTimeOffset Start, DateTimeOffset End);
