namespace After.Events;

public sealed class DomainEventDispatcher(IServiceProvider services)
{
    public void Dispatch(IEnumerable<IDomainEvent> events)
    {
        foreach (var domainEvent in events)
        {
            var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            var handlers = (IEnumerable<object>)services.GetService(typeof(IEnumerable<>).MakeGenericType(handlerType))!;

            foreach (var handler in handlers)
            {
                handlerType.GetMethod("Handle")!.Invoke(handler, [domainEvent]);
            }
        }
    }
}
