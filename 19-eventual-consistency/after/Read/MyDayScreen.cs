using After.Write;

namespace After.Read;

// A read model: a copy shaped for the screen, updated after the write.
public sealed class MyDayScreen
{
    private readonly List<string> _titles = [];

    public int Count => _titles.Count;

    public void Apply(BookingReserved reserved)
    {
        _titles.Add(reserved.Title);
    }
}
