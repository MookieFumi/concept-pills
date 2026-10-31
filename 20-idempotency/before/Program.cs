var bookings = new List<(Guid Id, string Room, string Title)>();

Guid Reserve(string room, string title)
{
    var id = Guid.NewGuid();
    bookings.Add((id, room, title));
    return id;
}

// The user double-clicks, or the client retries after a timeout.
var first = Reserve("Lisbon", "Planning");
var second = Reserve("Lisbon", "Planning");

Console.WriteLine($"Same booking returned? {first == second}");
Console.WriteLine($"Bookings stored: {bookings.Count}");
