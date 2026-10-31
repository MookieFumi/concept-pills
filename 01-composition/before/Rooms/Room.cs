namespace Before.Rooms;

public abstract class Room(string name, int capacity)
{
    public string Name { get; } = name;

    public int Capacity { get; } = capacity;
}
