using Before.Rooms;

var rooms = new Room[]
{
    new VideoConferenceRoom("Lisbon", 8),
    new WhiteboardRoom("Madrid", 6),
    new VideoConferenceWhiteboardRoom("Berlin", 12),
};

foreach (var room in rooms)
{
    // To use the equipment we need to know the exact subclass, and Berlin matches neither of the first two.
    switch (room)
    {
        case VideoConferenceWhiteboardRoom both:
            Console.WriteLine(both.StartCall("https://meet.example/berlin"));
            Console.WriteLine(both.CaptureWhiteboard());
            break;
        case VideoConferenceRoom video:
            Console.WriteLine(video.StartCall("https://meet.example/lisbon"));
            break;
        case WhiteboardRoom whiteboard:
            Console.WriteLine(whiteboard.CaptureWhiteboard());
            break;
    }
}
