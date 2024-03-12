using Cloupard.Services.Logger.Logger;
using Microsoft.Extensions.DependencyInjection;

namespace Cloupard.Services.Logger;

public static class DependencyInjection
{
    public static IServiceCollection AddAppLogger(this IServiceCollection services)
    {
        return services
            .AddSingleton<IAppLogger, AppLogger>();
    }
}