namespace Before.Calendar;

public sealed class BookingService(CalendarClient client)
{
    public void Reserve()
    {
        Retry.Run(client.Sync, retries: 3);
    }
}
