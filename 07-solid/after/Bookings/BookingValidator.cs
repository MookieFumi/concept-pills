namespace After.Bookings;

public sealed class BookingValidator(IEnumerable<IBookingRule> rules)
{
    public IReadOnlyList<string> Validate(BookingCandidate candidate)
    {
        return [.. rules.Select(rule => rule.Check(candidate)).OfType<string>()];
    }
}
