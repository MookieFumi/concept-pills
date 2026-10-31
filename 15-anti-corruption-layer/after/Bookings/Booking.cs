namespace After.Bookings;

public sealed record Booking(string RoomName, DateTimeOffset Start, DateTimeOffset End, BookingStatus Status)
{
    public bool IsActive => Status != BookingStatus.Cancelled;
}
