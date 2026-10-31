namespace Before.Bookings;

public sealed class SmtpNotifier
{
    public void Send(string recipient, string message)
    {
        Console.WriteLine($"SMTP to {recipient}: {message}");
    }
}
