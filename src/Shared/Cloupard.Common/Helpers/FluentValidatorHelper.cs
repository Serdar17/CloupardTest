using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cloupard.Common.Helpers;

public static class ValidatorsRegisterHelper
{
    public static void Register(IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(s => s.FullName != null && s.FullName.ToLower().StartsWith("cloupard."));

        assemblies.ToList().ForEach(x => { services.AddValidatorsFromAssembly(x, ServiceLifetime.Singleton); });
    }
}