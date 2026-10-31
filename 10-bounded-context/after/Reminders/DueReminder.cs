namespace After.Reminders;

// The reminders model: just what is needed to tell someone that a meeting is about to start.
public sealed record DueReminder(Guid BookingId, string OrganizerId, string Title, string RoomName, DateTimeOffset StartAt);
