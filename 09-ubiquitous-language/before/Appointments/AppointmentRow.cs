namespace Before.Appointments;

// The table is called Appointments. Status 1 = open, 3 = "removed". Nobody wrote that down.
public sealed class AppointmentRow
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public required string RoomName { get; init; }

    public DateTimeOffset From { get; init; }

    public DateTimeOffset To { get; init; }

    public int Status { get; set; } = 1;
}
