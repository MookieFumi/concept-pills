using Before.Services;

var rooms = new RoomService();
var catering = new CateringService();
var bookingId = Guid.NewGuid();

try
{
    // Two services, two local transactions, nothing to undo the first one.
    rooms.Hold(bookingId);
    catering.Order(bookingId);
}
catch (InvalidOperationException e)
{
    Console.WriteLine($"Failed: {e.Message}");
}

Console.WriteLine($"Room still held by a booking that never completed: {rooms.Held.Contains(bookingId)}");
