using System.Globalization;
using After.Bookings;

namespace After.Calendar;

// The anti-corruption layer: the only place that knows the provider's codes and formats.
public sealed class CalendarBookingSource(ExternalCalendarClient client) : IBookingSource
{
    public IReadOnlyList<Booking> GetBookings()
    {
        return client.GetEvents().Select(Translate).ToList();
    }

    private static Booking Translate(ExternalEvent e)
    {
        var start = DateTimeOffset.ParseExact(e.Dt, "yyyyMMddHHmm", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
        return new Booking(e.Room, start, start.AddMinutes(e.Dur), ToStatus(e));
    }

    private static BookingStatus ToStatus(ExternalEvent e)
    {
        return e.Stat switch
        {
            1 => BookingStatus.Confirmed,
            2 => BookingStatus.Tentative,
            3 or 9 => BookingStatus.Cancelled,
            _ => throw new InvalidOperationException($"Unknown status {e.Stat} in event {e.Id}."),
        };
    }
}
