namespace Before.Rooms;

public class WhiteboardRoom(string name, int capacity) : Room(name, capacity)
{
    public string CaptureWhiteboard()
    {
        return $"{Name}: whiteboard captured";
    }
}
