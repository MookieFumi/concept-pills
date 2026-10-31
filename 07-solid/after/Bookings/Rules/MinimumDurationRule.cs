namespace After.Bookings.Rules;

public sealed class MinimumDurationRule : IBookingRule
{
    private static readonly TimeSpan Minimum = TimeSpan.FromMinutes(15);

    public string? Check(BookingCandidate candidate)
    {
        return candidate.EndAt - candidate.StartAt < Minimum ? "A booking lasts at least 15 minutes." : null;
    }
}
