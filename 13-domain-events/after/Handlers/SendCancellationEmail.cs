using After.Events;

namespace After.Handlers;

public sealed class SendCancellationEmail : IDomainEventHandler<BookingCancelled>
{
    public void Handle(BookingCancelled domainEvent)
    {
        Console.WriteLine($"  email: '{domainEvent.Title}' cancelled");
    }
}
