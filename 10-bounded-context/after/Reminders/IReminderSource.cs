namespace After.Reminders;

public interface IReminderSource
{
    IReadOnlyList<DueReminder> StartingBetween(DateTimeOffset from, DateTimeOffset until);
}
