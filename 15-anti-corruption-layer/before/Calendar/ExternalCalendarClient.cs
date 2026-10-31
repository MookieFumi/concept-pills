namespace Before.Calendar;

public sealed class ExternalCalendarClient
{
    public IReadOnlyList<ExternalEvent> GetEvents()
    {
        return
        [
            new ExternalEvent("e1", "Lisbon", 1, "202601121000", 60),
            new ExternalEvent("e2", "Madrid", 3, "202601121100", 30),
            new ExternalEvent("e3", "Berlin", 9, "202601121400", 45),
        ];
    }
}
