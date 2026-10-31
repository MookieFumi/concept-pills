namespace Before.Bookings;

public sealed class Booking(Guid id, string title)
{
    public Guid Id { get; } = id;

    public string Title { get; } = title;

    public bool IsCancelled { get; private set; }

    // The rule is one line. Everything else is "also tell everybody".
    public void Cancel(IEmailSender email, ICatering catering, ICalendar calendar)
    {
        IsCancelled = true;
        email.SendCancellation(Title);
        catering.ReleaseOrder(Id);
        calendar.RemoveEvent(Id);
    }
}
