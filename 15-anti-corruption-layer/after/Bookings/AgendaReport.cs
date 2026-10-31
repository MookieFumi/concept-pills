using System.Globalization;

namespace After.Bookings;

public sealed class AgendaReport(IBookingSource source)
{
    public int CountActiveBookings()
    {
        return source.GetBookings().Count(b => b.IsActive);
    }

    public string FirstEndTime()
    {
        return source.GetBookings()[0].End.ToString("HH:mm", CultureInfo.InvariantCulture);
    }
}
