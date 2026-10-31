using After.Saga;
using After.Services;

var rooms = new RoomService();
var catering = new CateringService { FailOnOrder = true };
var bookingId = Guid.NewGuid();

BookingSaga NewSaga()
{
    return new BookingSaga(
    [
        new SagaStep("Hold room", () => rooms.Hold(bookingId), () => rooms.Release(bookingId)),
        new SagaStep("Order catering", () => catering.Order(bookingId), () => { }),
    ]);
}

var saga = NewSaga();
saga.Run();
Console.WriteLine($"Catering failed. Saga status: {saga.Status}");
Console.WriteLine($"Room still held: {rooms.Held.Contains(bookingId)}");

// When the compensation fails too, the status says so instead of pretending everything is fine.
rooms.FailOnRelease = true;
var stuck = NewSaga();
stuck.Run();
Console.WriteLine($"Catering failed and the room could not be released. Saga status: {stuck.Status}");
