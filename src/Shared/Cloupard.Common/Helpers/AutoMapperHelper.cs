using Microsoft.Extensions.DependencyInjection;

namespace Cloupard.Common.Helpers;

public static class AutoMappersRegisterHelper
{
    public static void Register(IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(s => s.FullName != null && s.FullName.ToLower().StartsWith("cloupard."));

        services.AddAutoMapper(assemblies);
    }
}