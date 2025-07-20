using System.Diagnostics;

namespace MotoGP.API.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var request = context.Request;
        Console.WriteLine($"➡️  {request.Method} {request.Path}");

        await _next(context); // tiếp tục middleware tiếp theo

        stopwatch.Stop();
        var response = context.Response;
        Console.WriteLine($"⬅️  {response.StatusCode} ({stopwatch.ElapsedMilliseconds} ms)");
    }
}
