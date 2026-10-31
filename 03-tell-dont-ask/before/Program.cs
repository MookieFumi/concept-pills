using Before.Rooms;

var booking = new Booking
{
    Room = new Room { Name = "Berlin", Capacity = 12, Equipment = ["video", "whiteboard"] },
    Attendees = 10,
    RequiredEquipment = ["video"],
};

// The caller digs through Booking -> Room -> Equipment and applies the room's rules itself.
// Every other place that needs the same check has to copy this condition.
var fits = booking.Room.IsActive
    && booking.Attendees <= booking.Room.Capacity
    && booking.RequiredEquipment.All(item => booking.Room.Equipment.Contains(item));

Console.WriteLine($"Fits: {fits}");
