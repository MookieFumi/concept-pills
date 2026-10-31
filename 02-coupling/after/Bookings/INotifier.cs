namespace After.Bookings;

public interface INotifier
{
    void Send(string recipient, string message);
}
