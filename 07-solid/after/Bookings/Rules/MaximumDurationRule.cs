namespace After.Bookings.Rules;

public sealed class MaximumDurationRule : IBookingRule
{
    private static readonly TimeSpan Maximum = TimeSpan.FromHours(4);

    public string? Check(BookingCandidate candidate)
    {
        return candidate.EndAt - candidate.StartAt > Maximum ? "A booking lasts at most 4 hours." : null;
    }
}
