namespace Before.Bookings;

// One model for everybody: the reservations code and the reminders code both depend on every field.
public sealed class Booking
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public required string RoomName { get; init; }

    public int RoomCapacity { get; init; }

    public required string OrganizerId { get; init; }

    public required string Title { get; init; }

    public DateTimeOffset StartAt { get; init; }

    public DateTimeOffset EndAt { get; init; }

    public int Attendees { get; init; }

    public string Status { get; set; } = "Confirmed";

    public DateTimeOffset? CancelledAt { get; set; }

    public DateTimeOffset? ReminderSentAt { get; set; }

    public string ReminderChannel { get; set; } = "email";
}
