using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Shared.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServicesFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        var types = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Service"))
            .ToList();

        foreach (var impl in types)
        {
            var serviceInterface = impl.GetInterface($"I{impl.Name}");
            if (serviceInterface != null)
            {
                services.AddScoped(serviceInterface, impl);
            }
        }

        return services;
    }
}
