using After.Events;

namespace After.Handlers;

// Added later: Booking.Cancel() did not change.
public sealed class FreeRoomForWaitingList : IDomainEventHandler<BookingCancelled>
{
    public void Handle(BookingCancelled domainEvent)
    {
        Console.WriteLine("  waiting list: slot offered to the next team");
    }
}
