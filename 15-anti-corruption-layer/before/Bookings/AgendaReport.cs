using System.Globalization;
using Before.Calendar;

namespace Before.Bookings;

// Domain code reading the provider's codes and formats directly.
public sealed class AgendaReport(ExternalCalendarClient calendar)
{
    public int CountActiveBookings()
    {
        return calendar.GetEvents().Count(e => e.Stat != 3);
    }

    public string FirstEndTime()
    {
        var first = calendar.GetEvents()[0];
        var start = DateTime.ParseExact(first.Dt, "yyyyMMddHHmm", null);
        return start.AddMinutes(first.Dur).ToString("HH:mm", CultureInfo.InvariantCulture);
    }
}
