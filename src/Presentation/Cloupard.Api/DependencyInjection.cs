using Cloupard.Api.Configuration;
using Cloupard.Application;
using Cloupard.Infrastructure;
using Cloupard.Services.Logger;
using Cloupard.Services.Settings;

namespace Cloupard.Api;

/// <summary>
/// Extension method
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registration services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services
            .AddAppLogger()
            .AddMainSettings()
            .AddSwaggerSettings()
            .AddLogSettings()
            .AddWebSettings()
            .AddAppVersioning()
            .AddInfrastructure()
            .AddApplication()
            .AddAppAutoMappers();
        
        return services;
    }
}