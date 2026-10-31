using Before.Dtos;
using Before.Models;
using Before.Repositories;

namespace Before.Services;

public sealed class BookingService(IBookingRepository repository) : IBookingService
{
    public Booking Reserve(ReserveRequest request)
    {
        var booking = new Booking(Guid.NewGuid(), request.RoomName, request.Start);
        repository.Add(booking);
        return booking;
    }

    public Booking ReserveWithCatering(ReserveWithCateringRequest request)
    {
        var booking = new Booking(Guid.NewGuid(), request.RoomName, request.Start)
        {
            CateringMenu = request.Menu,
        };
        repository.Add(booking);
        return booking;
    }

    public void Cancel(Guid id)
    {
        var booking = repository.Find(id) ?? throw new InvalidOperationException("Booking not found.");
        booking.IsCancelled = true;
    }
}
