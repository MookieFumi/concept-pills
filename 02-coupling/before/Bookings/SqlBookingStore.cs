namespace Before.Bookings;

public sealed class SqlBookingStore
{
    public void Insert(BookingRequest request)
    {
        Console.WriteLine($"INSERT booking for {request.RoomName} at {request.StartAt:u}");
    }
}
