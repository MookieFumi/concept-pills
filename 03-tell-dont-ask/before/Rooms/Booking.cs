namespace Before.Rooms;

public sealed class Booking
{
    public required Room Room { get; init; }

    public int Attendees { get; init; }

    public List<string> RequiredEquipment { get; init; } = [];
}
