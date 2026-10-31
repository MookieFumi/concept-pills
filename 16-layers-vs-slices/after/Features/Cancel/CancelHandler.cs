using After.Data;

namespace After.Features.Cancel;

public sealed class CancelHandler(BookingStore store)
{
    public void Handle(Guid id)
    {
        var booking = store.Find(id) ?? throw new InvalidOperationException("Booking not found.");
        booking.Cancel();
    }
}
