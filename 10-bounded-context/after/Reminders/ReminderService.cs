namespace After.Reminders;

public sealed class ReminderService(IReminderSource source)
{
    public void RemindBookingsStartingBefore(DateTimeOffset now, TimeSpan leadTime)
    {
        foreach (var reminder in source.StartingBetween(now, now + leadTime))
        {
            Console.WriteLine($"Reminder for {reminder.OrganizerId}: '{reminder.Title}' in {reminder.RoomName}");
        }
    }
}
