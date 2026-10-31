namespace After.Rooms;

public sealed class VideoSystem : IEquipment
{
    public string Name => "Video system";

    public string StartCall(string meetingLink)
    {
        return $"{Name}: call started at {meetingLink}";
    }
}
