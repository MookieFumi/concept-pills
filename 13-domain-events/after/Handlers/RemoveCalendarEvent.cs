using After.Events;

namespace After.Handlers;

public sealed class RemoveCalendarEvent : IDomainEventHandler<BookingCancelled>
{
    public void Handle(BookingCancelled domainEvent)
    {
        Console.WriteLine("  calendar: event removed");
    }
}
