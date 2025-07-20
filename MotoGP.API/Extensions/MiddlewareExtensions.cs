using MotoGP.API.Middleware;
using MotoGP.Shared.Exceptions;

namespace MotoGP.API.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app)
        => app.UseMiddleware<ExceptionHandlingMiddleware>();

    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        => app.UseMiddleware<ExceptionHandlingMiddleware>();

    public static IApplicationBuilder UseJwtValidation(this IApplicationBuilder app)
        => app.UseMiddleware<ExceptionHandlingMiddleware>();

    public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app)
        => app.UseMiddleware<ExceptionHandlingMiddleware>();
}
