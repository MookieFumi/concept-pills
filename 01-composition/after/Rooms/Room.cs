namespace After.Rooms;

public sealed class Room(string name, int capacity, params IEquipment[] equipment)
{
    public string Name { get; } = name;

    public int Capacity { get; } = capacity;

    public IReadOnlyCollection<IEquipment> Equipment { get; } = equipment;

    public T? Find<T>() where T : class, IEquipment
    {
        return Equipment.OfType<T>().FirstOrDefault();
    }
}
