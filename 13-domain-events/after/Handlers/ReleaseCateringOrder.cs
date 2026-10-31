using After.Events;

namespace After.Handlers;

public sealed class ReleaseCateringOrder : IDomainEventHandler<BookingCancelled>
{
    public void Handle(BookingCancelled domainEvent)
    {
        Console.WriteLine("  catering: order released");
    }
}
