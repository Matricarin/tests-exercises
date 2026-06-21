namespace Task002_Throttling;

public sealed class ThrottlingSolver
{
    public static async Task ProcessUrlsAsync
    (
        IEnumerable<string> urls,
        int maxParallelism,
        CancellationToken token
    )
    {
        using var semaphore = new SemaphoreSlim(maxParallelism);

        var tasks = urls.Select(s => ProcessUrl(s, semaphore, token));

        await Task.WhenAll(tasks);
    }

    private static async Task ProcessUrl(string url, SemaphoreSlim semaphore, CancellationToken token)
    {
        try
        {
            await semaphore.WaitAsync(token);
            await Task.Delay(url.Length + 1000, token);
        }
        finally
        {
            semaphore.Release();
        }
    }
}