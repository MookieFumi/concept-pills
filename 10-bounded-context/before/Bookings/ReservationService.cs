namespace Before.Bookings;

public sealed class ReservationService
{
    public List<Booking> Bookings { get; } = [];

    public Booking Create(string roomName, string organizerId, string title, DateTimeOffset startAt)
    {
        // Creating a booking has to know about reminder fields too, because they live on the same class.
        var booking = new Booking
        {
            RoomName = roomName,
            RoomCapacity = 12,
            OrganizerId = organizerId,
            Title = title,
            StartAt = startAt,
            EndAt = startAt.AddHours(1),
            Attendees = 4,
            ReminderChannel = "email",
        };
        Bookings.Add(booking);

        return booking;
    }
}
