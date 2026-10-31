using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using Polly.Timeout;

namespace After.Calendar;

// Resilience lives in one place: the call to the dependency.
public sealed class CalendarClient(FailingCalendar calendar)
{
    private readonly ResiliencePipeline _pipeline = new ResiliencePipelineBuilder()
        .AddRetry(new RetryStrategyOptions
        {
            MaxRetryAttempts = 2,
            BackoffType = DelayBackoffType.Exponential,
            Delay = TimeSpan.FromMilliseconds(1),
            UseJitter = true,
            ShouldHandle = new PredicateBuilder().Handle<HttpRequestException>(),
        })
        .AddCircuitBreaker(new CircuitBreakerStrategyOptions
        {
            FailureRatio = 0.5,
            MinimumThroughput = 5,
            SamplingDuration = TimeSpan.FromSeconds(30),
            BreakDuration = TimeSpan.FromSeconds(30),
            ShouldHandle = new PredicateBuilder().Handle<HttpRequestException>(),
        })
        .AddTimeout(TimeSpan.FromSeconds(2))
        .Build();

    public bool TrySync()
    {
        try
        {
            _pipeline.Execute(calendar.Sync);
            return true;
        }
        catch (Exception e) when (e is HttpRequestException or BrokenCircuitException or TimeoutRejectedException)
        {
            return false;
        }
    }
}
