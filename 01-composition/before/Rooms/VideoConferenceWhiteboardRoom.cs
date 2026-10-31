namespace Before.Rooms;

// C# has no multiple inheritance, so the room that has both pieces of equipment
// copies the code of the two classes above. A third piece of equipment doubles the classes again.
public class VideoConferenceWhiteboardRoom(string name, int capacity) : Room(name, capacity)
{
    public string StartCall(string meetingLink)
    {
        return $"{Name}: call started at {meetingLink}";
    }

    public string CaptureWhiteboard()
    {
        return $"{Name}: whiteboard captured";
    }
}
