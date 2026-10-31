namespace Before.Calendar;

public static class Retry
{
    // Every layer brings its own "just in case" retry.
    public static void Run(Action action, int retries)
    {
        for (var attempt = 0; ; attempt++)
        {
            try
            {
                action();
                return;
            }
            catch (HttpRequestException) when (attempt < retries)
            {
            }
        }
    }
}
