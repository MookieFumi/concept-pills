namespace After.Messaging;

// At-least-once delivery means duplicates: the consumer remembers what it has processed.
public sealed class IdempotentConsumer
{
    private readonly HashSet<Guid> _processed = [];

    public int ProcessedCount => _processed.Count;

    public void Handle(Guid messageId)
    {
        _processed.Add(messageId);
    }
}
