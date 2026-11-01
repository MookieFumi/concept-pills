namespace After.Services;

public sealed class CateringService
{
    public bool FailOnOrder { get; set; }

    public void Order(Guid bookingId)
    {
        if (FailOnOrder)
        {
            throw new InvalidOperationException("The caterer cannot serve this room.");
        }
    }
}
