// Two stores that must agree: the bookings, and a copy used by the "my day" screen.
var bookings = new List<string>();
var screen = new List<string>();

void Reserve(string title)
{
    bookings.Add(title);
    // The copy is refreshed by a background job later. The code does not admit it.
}

void RefreshScreenCopy()
{
    screen.Clear();
    screen.AddRange(bookings);
}

Reserve("Planning");
Console.WriteLine($"Screen right after reserving: {screen.Count}");

// The user does not see it, assumes it failed, and tries again.
if (screen.Count == 0)
{
    Reserve("Planning");
}

Console.WriteLine($"Bookings stored: {bookings.Count}");

RefreshScreenCopy();
Console.WriteLine($"Screen after the refresh job: {screen.Count}");
