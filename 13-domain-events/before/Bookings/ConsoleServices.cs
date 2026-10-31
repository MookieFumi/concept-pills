namespace Before.Bookings;

public sealed class ConsoleServices : IEmailSender, ICatering, ICalendar
{
    public void SendCancellation(string title)
    {
        Console.WriteLine($"  email: '{title}' cancelled");
    }

    public void ReleaseOrder(Guid bookingId)
    {
        Console.WriteLine("  catering: order released");
    }

    public void RemoveEvent(Guid bookingId)
    {
        Console.WriteLine("  calendar: event removed");
    }
}
