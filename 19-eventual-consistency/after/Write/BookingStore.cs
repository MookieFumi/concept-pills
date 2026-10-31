namespace After.Write;

public sealed class BookingStore
{
    private readonly Dictionary<Guid, string> _titles = [];

    public Guid Add(string title, Queue<BookingReserved> outbox)
    {
        var id = Guid.NewGuid();
        _titles[id] = title;
        outbox.Enqueue(new BookingReserved(id, title));
        return id;
    }

    public string? Find(Guid id)
    {
        return _titles.GetValueOrDefault(id);
    }
}
