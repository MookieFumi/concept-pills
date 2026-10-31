namespace After.Bookings;

public sealed class ConsoleNotifier : INotifier
{
    public void Send(string recipient, string message)
    {
        Console.WriteLine($"Notify {recipient}: {message}");
    }
}
