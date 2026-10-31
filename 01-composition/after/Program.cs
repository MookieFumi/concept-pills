using After.Rooms;

var rooms = new[]
{
    new Room("Lisbon", 8, new VideoSystem()),
    new Room("Madrid", 6, new Whiteboard()),
    new Room("Berlin", 12, new VideoSystem(), new Whiteboard()),
};

foreach (var room in rooms)
{
    // No subclass to guess: each room is asked for the equipment it has.
    if (room.Find<VideoSystem>() is { } video)
    {
        Console.WriteLine($"{room.Name}: {video.StartCall($"https://meet.example/{room.Name.ToLowerInvariant()}")}");
    }

    if (room.Find<Whiteboard>() is { } whiteboard)
    {
        Console.WriteLine($"{room.Name}: {whiteboard.Capture()}");
    }
}
