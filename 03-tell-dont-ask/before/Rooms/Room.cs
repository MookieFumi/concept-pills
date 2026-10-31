namespace Before.Rooms;

public sealed class Room
{
    public required string Name { get; init; }

    public int Capacity { get; init; }

    public bool IsActive { get; init; } = true;

    public List<string> Equipment { get; init; } = [];
}
