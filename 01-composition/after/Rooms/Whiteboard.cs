namespace After.Rooms;

public sealed class Whiteboard : IEquipment
{
    public string Name => "Whiteboard";

    public string Capture()
    {
        return "whiteboard captured";
    }
}
