namespace Before.Rooms;

public class VideoConferenceRoom(string name, int capacity) : Room(name, capacity)
{
    public string StartCall(string meetingLink)
    {
        return $"{Name}: call started at {meetingLink}";
    }
}
