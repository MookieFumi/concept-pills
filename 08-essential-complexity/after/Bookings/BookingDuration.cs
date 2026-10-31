namespace After.Bookings;

/// <summary>The essential rule: a booking lasts between 15 minutes and 4 hours.</summary>
public static class BookingDuration
{
    public static readonly TimeSpan Minimum = TimeSpan.FromMinutes(15);

    public static readonly TimeSpan Maximum = TimeSpan.FromHours(4);

    public static string? Check(DateTimeOffset start, DateTimeOffset end)
    {
        var duration = end - start;

        if (duration < Minimum)
        {
            return $"A booking lasts at least {Minimum.TotalMinutes:0} minutes.";
        }

        return duration > Maximum ? $"A booking lasts at most {Maximum.TotalHours:0} hours." : null;
    }
}
