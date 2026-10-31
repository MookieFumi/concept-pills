using After.Events;

namespace After.Bookings;

public sealed class Booking(Guid id, string title)
{
    private readonly List<IDomainEvent> _events = [];

    public Guid Id { get; } = id;

    public string Title { get; } = title;

    public bool IsCancelled { get; private set; }

    public IReadOnlyList<IDomainEvent> Events => _events;

    // The aggregate states what happened. It does not know who cares.
    public void Cancel()
    {
        if (IsCancelled)
        {
            return;
        }

        IsCancelled = true;
        _events.Add(new BookingCancelled(Id, Title));
    }

    public void ClearEvents()
    {
        _events.Clear();
    }
}
