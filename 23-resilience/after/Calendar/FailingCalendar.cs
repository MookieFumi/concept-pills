namespace After.Calendar;

// A dependency that is having a bad day: every call fails and costs it work.
public sealed class FailingCalendar
{
    public int Calls { get; private set; }

    public void Sync()
    {
        Calls++;
        throw new HttpRequestException("Calendar service unavailable.");
    }
}
