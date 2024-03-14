using Cloupard.MVC.Configuration;
using Cloupard.MVC.Services;
using Cloupard.Services.Logger;
using Cloupard.Services.Settings;

namespace Cloupard.MVC;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services
            .AddWebSettings()
            .AddMainSettings()
            .AddAppCors()
            .AddAppLogger()
            .AddHttpClient<IProductService, ProductService>();
        
        
        return services;
    }
}