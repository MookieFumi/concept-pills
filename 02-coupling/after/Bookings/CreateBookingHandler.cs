namespace After.Bookings;

public sealed class CreateBookingHandler(IBookingStore store, INotifier notifier, IClock clock)
{
    public bool Handle(BookingRequest request)
    {
        if (request.StartAt < clock.Now)
        {
            Console.WriteLine("Rejected: the booking starts in the past.");
            return false;
        }

        store.Insert(request);
        notifier.Send(request.OrganizerEmail, $"{request.RoomName} booked");

        return true;
    }
}
