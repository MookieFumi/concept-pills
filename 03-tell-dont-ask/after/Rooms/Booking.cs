namespace After.Rooms;

public sealed class Booking(Room room, int attendees, IReadOnlyCollection<string> requiredEquipment)
{
    public bool Fits()
    {
        return room.CanHost(attendees, requiredEquipment);
    }
}
