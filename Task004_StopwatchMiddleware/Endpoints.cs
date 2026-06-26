namespace Task004_StopwatchMiddleware;

public static class Endpoints
{
    public static void AddEndpoints(this WebApplication app)
    {
        app.MapGroup("/stopwatch")
            .MapGet("/resource1", () => Results.Ok());
    }
}