namespace Task004_StopwatchMiddleware;

public class StopwatchMiddleware : IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {


        return next.Invoke(context);
    }
}