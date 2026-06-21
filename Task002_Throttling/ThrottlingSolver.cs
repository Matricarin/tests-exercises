namespace Task002_Throttling;

public sealed class ThrottlingSolver
{
    public static async Task<List<string>> ProcessUrlsAsync
    (
        IEnumerable<string> urls,
        int maxParallelism,
        CancellationToken token)
    {
        using var semaphore = new SemaphoreSlim(maxParallelism);

        var tasks = urls.Select(s => ProcessUrl(s, semaphore, token));

       var result = await Task.WhenAll(tasks);

       return result.SelectMany(l => l).ToList();
    }

    private static async Task<List<string>> ProcessUrl(string url, SemaphoreSlim semaphore, CancellationToken token)
    {
        var list = new List<string>();
        try
        {
            list.Add($"Задача создана {url}. Ожидание слоты. Current count: {semaphore.CurrentCount}");

            await semaphore.WaitAsync(token);

            list.Add($"Слот занят! Выполнение работыы {url}.");
            await Task.Delay(url.Length + 1000, token);
        }
        finally
        {
            list.Add($"Конец обработки {url}");
            semaphore.Release();
        }

        return list;
    }
}