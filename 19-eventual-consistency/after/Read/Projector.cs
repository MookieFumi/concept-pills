using After.Write;

namespace After.Read;

public sealed class Projector(Queue<BookingReserved> outbox, MyDayScreen screen)
{
    public void RunOnce()
    {
        while (outbox.Count > 0)
        {
            screen.Apply(outbox.Dequeue());
        }
    }
}
