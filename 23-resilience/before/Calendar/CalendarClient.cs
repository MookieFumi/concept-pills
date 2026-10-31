namespace Before.Calendar;

public sealed class CalendarClient(FailingCalendar calendar)
{
    public void Sync()
    {
        Retry.Run(calendar.Sync, retries: 3);
    }
}
