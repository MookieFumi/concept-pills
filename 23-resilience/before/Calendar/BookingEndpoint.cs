namespace Before.Calendar;

public sealed class BookingEndpoint(BookingService service)
{
    public bool Post()
    {
        try
        {
            Retry.Run(service.Reserve, retries: 3);
            return true;
        }
        catch (HttpRequestException)
        {
            return false;
        }
    }
}
