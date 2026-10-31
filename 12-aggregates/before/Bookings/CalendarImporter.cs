namespace Before.Bookings;

// ...but nothing forces other code to go through it.
public sealed class CalendarImporter(BookingStore store)
{
    public void Import(string roomName, string title, DateTimeOffset startAt, DateTimeOffset endAt)
    {
        store.All.Add(new Booking(Guid.NewGuid(), roomName, title, startAt, endAt));
    }
}
