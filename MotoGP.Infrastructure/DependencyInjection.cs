using Microsoft.Extensions.DependencyInjection;
using MotoGP.Application.Auth;
using MotoGP.Application.Interfaces.Services;
using MotoGP.Application.Interfaces;
using MotoGP.Infrastructure.Auth;
using MotoGP.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotoGP.Infrastructure.UnitOfWorks;

namespace MotoGP.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Dependency Injection
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddTransient<INewsService, NewsService>();
        services.AddTransient<IVideoService, VideoService>();
        services.AddTransient<IRaceEventService, RaceEventService>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<ITokenService, TokenService>();

        return services;
    }
}
