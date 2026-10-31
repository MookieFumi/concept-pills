namespace After.Rooms;

public sealed class Room(string name, int capacity, IEnumerable<string> equipment, bool isActive = true)
{
    private readonly HashSet<string> _equipment = [.. equipment];

    public string Name { get; } = name;

    public bool CanHost(int attendees, IReadOnlyCollection<string> requiredEquipment)
    {
        return isActive
            && attendees <= capacity
            && requiredEquipment.All(_equipment.Contains);
    }
}
