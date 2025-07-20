using MotoGP.Application.Auth;
using MotoGP.Application.Interfaces.Services;
using MotoGP.Application.Interfaces;
using MotoGP.Infrastructure.Auth;
using MotoGP.Infrastructure.Services;
using MotoGP.Infrastructure.UnitOfWorks;
using MotoGP.Infrastructure;

namespace MotoGP.API.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        return DependencyInjection.AddApplicationServices(services);
    }
}
