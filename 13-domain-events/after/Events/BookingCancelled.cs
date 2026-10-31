namespace After.Events;

// Past tense, immutable: something that already happened.
public sealed record BookingCancelled(Guid BookingId, string Title) : IDomainEvent;
