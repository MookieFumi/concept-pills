using System.Globalization;

namespace Before.Bookings;

public static class BookingChecker
{
    // The business rule is "between 15 minutes and 4 hours". Finding it takes a while.
    public static string Check(Dictionary<string, object?> data)
    {
        if (!data.TryGetValue("start", out var startValue) || startValue is null)
        {
            return "ERR1";
        }

        if (!data.TryGetValue("end", out var endValue) || endValue is null)
        {
            return "ERR2";
        }

        var start = DateTimeOffset.Parse(startValue.ToString()!, CultureInfo.InvariantCulture);
        var end = DateTimeOffset.Parse(endValue.ToString()!, CultureInfo.InvariantCulture);
        var minutes = (end - start).TotalMinutes;

        // TODO: remove when the old mobile app is gone
        if (data.ContainsKey("legacy") && (bool)data["legacy"]!)
        {
            return minutes >= 15 ? "OK" : "ERR3";
        }

        return minutes >= 15 && minutes <= 240 ? "OK" : "ERR3";
    }
}
