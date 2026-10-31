namespace Before.Bookings;

// It builds its own collaborators and reads the system clock, so a test needs a real
// database, a real mail server and the right time of day.
public sealed class CreateBookingHandler
{
    private readonly SqlBookingStore _store = new();
    private readonly SmtpNotifier _notifier = new();

    public bool Handle(BookingRequest request)
    {
        if (request.StartAt < DateTimeOffset.UtcNow)
        {
            Console.WriteLine("Rejected: the booking starts in the past.");
            return false;
        }

        _store.Insert(request);
        _notifier.Send(request.OrganizerEmail, $"{request.RoomName} booked");

        return true;
    }
}
