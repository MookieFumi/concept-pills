namespace After.Messaging;

// A broker that can be down, or deliver a message and lose the acknowledgement.
public sealed class FlakyBroker
{
    public bool IsDown { get; set; }

    public bool LoseNextAck { get; set; }

    public List<Guid> Received { get; } = [];

    public void Publish(Guid messageId)
    {
        if (IsDown)
        {
            throw new InvalidOperationException("Broker is down.");
        }

        Received.Add(messageId);

        if (LoseNextAck)
        {
            LoseNextAck = false;
            throw new TimeoutException("Acknowledgement lost.");
        }
    }
}
