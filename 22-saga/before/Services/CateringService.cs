namespace Before.Services;

public sealed class CateringService
{
    public void Order(Guid bookingId)
    {
        throw new InvalidOperationException("The caterer cannot serve this room.");
    }
}
