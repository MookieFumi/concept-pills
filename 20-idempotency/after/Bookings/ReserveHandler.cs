namespace After.Bookings;

public sealed class ReserveHandler
{
    private readonly List<(Guid Id, string Room, string Title)> _bookings = [];

    // The key remembers the request it came with and the answer given to it.
    private readonly Dictionary<string, (ReserveCommand Command, Guid BookingId)> _seenKeys = [];

    public int BookingsStored => _bookings.Count;

    public ReserveResult Handle(string idempotencyKey, ReserveCommand command)
    {
        if (_seenKeys.TryGetValue(idempotencyKey, out var seen))
        {
            return seen.Command == command
                ? new ReserveResult(ReserveOutcome.Replayed, seen.BookingId)
                : new ReserveResult(ReserveOutcome.KeyReusedWithDifferentRequest, null);
        }

        var id = Guid.NewGuid();
        _bookings.Add((id, command.Room, command.Title));
        _seenKeys[idempotencyKey] = (command, id);
        return new ReserveResult(ReserveOutcome.Created, id);
    }
}
