using After.Bookings;
using After.Events;
using After.Handlers;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddSingleton<IDomainEventHandler<BookingCancelled>, SendCancellationEmail>()
    .AddSingleton<IDomainEventHandler<BookingCancelled>, ReleaseCateringOrder>()
    .AddSingleton<IDomainEventHandler<BookingCancelled>, RemoveCalendarEvent>()
    .AddSingleton<IDomainEventHandler<BookingCancelled>, FreeRoomForWaitingList>()
    .BuildServiceProvider();

var booking = new Booking(Guid.NewGuid(), "Planning");

booking.Cancel();
Console.WriteLine($"Cancel() needs no collaborators. Events recorded: {booking.Events.Count}");

booking.Cancel();
Console.WriteLine($"Cancelling twice records still: {booking.Events.Count}");

Console.WriteLine("The application layer dispatches them after saving:");
new DomainEventDispatcher(services).Dispatch(booking.Events);
booking.ClearEvents();
