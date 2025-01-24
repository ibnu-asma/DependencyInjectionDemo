using DependencyInjectionDemo.IServices;
using DependencyInjectionDemo.Services;

namespace DependencyInjectionDemo.Extensions;


public static class LifeTimeServicesCollectionExtension
{
    public static IServiceCollection AddLifeTimeServices(this IServiceCollection services)
    {
        services.AddScoped<IScopedService, ScopedService>();
        services.AddTransient<ITransientService, TransientService>();
        services.AddSingleton<ISingletonService, SingletonService>();
        return services;
    }   
}