using Microsoft.AspNetCore.Http.HttpResults;

namespace Task004_StopwatchMiddleware;

public static class Endpoints
{
    public static void AddEndpoints(this WebApplication app)
    {
        app.MapGroup("/stopwatch")
            .MapGet("/elapsed", GetElapsed);
    }

    private static IResult GetElapsed()
    {
        return Results.Ok();
    }
}