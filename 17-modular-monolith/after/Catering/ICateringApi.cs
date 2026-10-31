namespace Catering;

public interface ICateringApi
{
    string Order(Guid bookingId, string menu);
}
