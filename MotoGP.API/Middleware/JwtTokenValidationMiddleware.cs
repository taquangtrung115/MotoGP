using System.IdentityModel.Tokens.Jwt;

namespace MotoGP.API.Middleware;

public class JwtTokenValidationMiddleware
{
    private readonly RequestDelegate _next;

    public JwtTokenValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (!string.IsNullOrWhiteSpace(token))
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                if (!handler.CanReadToken(token))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Invalid JWT token format.");
                    return;
                }
            }
            catch
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid JWT token.");
                return;
            }
        }

        await _next(context);
    }
}
