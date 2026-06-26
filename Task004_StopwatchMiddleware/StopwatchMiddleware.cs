using System.Diagnostics;

namespace Task004_StopwatchMiddleware;

public class StopwatchMiddleware : IMiddleware
{
    private readonly ILogger<StopwatchMiddleware> _log;

    public StopwatchMiddleware(ILogger<StopwatchMiddleware> log)
    {
        _log = log;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var timer = Stopwatch.StartNew();

        await next.Invoke(context);

        var elapsed = timer.Elapsed;

        _log.LogInformation(elapsed.Milliseconds.ToString());

        context.Response.HttpContext.Items.Add("elapsed", elapsed.Milliseconds);
    }
}