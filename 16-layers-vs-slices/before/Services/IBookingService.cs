using Before.Dtos;
using Before.Models;

namespace Before.Services;

public interface IBookingService
{
    Booking Reserve(ReserveRequest request);

    Booking ReserveWithCatering(ReserveWithCateringRequest request);

    void Cancel(Guid id);
}
