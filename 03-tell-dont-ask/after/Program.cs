using After.Rooms;

var booking = new Booking(new Room("Berlin", 12, ["video", "whiteboard"]), 10, ["video"]);

// The caller tells the booking to check itself. The room rule lives in one place.
Console.WriteLine($"Fits: {booking.Fits()}");
