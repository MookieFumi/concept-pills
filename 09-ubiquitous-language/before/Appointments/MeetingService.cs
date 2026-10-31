namespace Before.Appointments;

// The service calls it a meeting, and "cancel" is a method named Remove.
public sealed class MeetingService
{
    private readonly List<AppointmentRow> _table = [];

    public Guid Add(ReservationDto reservation)
    {
        var row = new AppointmentRow { RoomName = reservation.RoomName, From = reservation.From, To = reservation.To };
        _table.Add(row);
        Console.WriteLine($"Added meeting {row.Id:N} in {row.RoomName}");

        return row.Id;
    }

    public void Remove(Guid meetingId)
    {
        var row = _table.Single(item => item.Id == meetingId);
        row.Status = 3;
        Console.WriteLine($"Removed meeting {row.Id:N} (status={row.Status})");
    }
}
