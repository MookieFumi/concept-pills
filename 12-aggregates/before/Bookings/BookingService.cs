namespace Before.Bookings;

public sealed class BookingService(BookingStore store)
{
    private const int MaxActivePerRoomPerDay = 3;

    // The overlap rule lives here...
    public bool TryBook(string roomName, string title, DateTimeOffset startAt, DateTimeOffset endAt)
    {
        var overlaps = store.All.Any(b => b.RoomName == roomName && b.StartAt < endAt && startAt < b.EndAt);
        var perDay = store.All.Count(b => b.RoomName == roomName && b.StartAt.Date == startAt.Date);

        if (overlaps || perDay >= MaxActivePerRoomPerDay)
        {
            return false;
        }

        store.All.Add(new Booking(Guid.NewGuid(), roomName, title, startAt, endAt));
        return true;
    }
}
