namespace Before.Bookings;

public interface IEmailSender
{
    void SendCancellation(string title);
}
