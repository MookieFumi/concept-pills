namespace After.Bookings;

// The importer has no shortcut: it goes through the root like everyone else.
public sealed class CalendarImporter
{
    public BookingResult Import(Room room, string title, TimeRange range)
    {
        return room.Book(title, range);
    }
}
