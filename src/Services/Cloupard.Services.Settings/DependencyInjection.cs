using Cloupard.Services.Settings.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cloupard.Services.Settings;

public static class DependencyInjection
{
    public static IServiceCollection AddMainSettings(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings =  Common.Settings.Settings.Load<MainSettings>(MainSettings.SectionName, configuration);
        services.AddSingleton(settings);

        return services;
    }

    public static IServiceCollection AddSwaggerSettings(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Common.Settings.Settings.Load<SwaggerSettings>(SwaggerSettings.SectionName, configuration);
        services.AddSingleton(settings);

        return services;
    }

    public static IServiceCollection AddLogSettings(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Common.Settings.Settings.Load<LogSettings>(LogSettings.SectionName, configuration);
        services.AddSingleton(settings);

        return services;
    }
    
    public static IServiceCollection AddWebSettings(this IServiceCollection services,
        IConfiguration configuration = null)
    {
        var settings = Common.Settings.Settings.Load<WebSettings>(WebSettings.SectionName, configuration);
        services.AddSingleton(settings);
        return services;
    }

}