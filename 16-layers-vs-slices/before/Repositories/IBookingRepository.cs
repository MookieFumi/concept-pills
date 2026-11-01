using Before.Models;

namespace Before.Repositories;

public interface IBookingRepository
{
    void Add(Booking booking);

    Booking? Find(Guid id);
}
