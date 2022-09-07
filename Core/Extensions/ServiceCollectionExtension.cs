using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddDependencyResolvers(this IServiceCollection services, params ICoreModule[] modules)
    {
        foreach (var module in modules) module.Load(services);
    }
}