using Cloupard.Common.Helpers;
using Cloupard.Common.Validator;
using FluentValidation.AspNetCore;

namespace Cloupard.Api.Configuration;

/// <summary>
/// Validation configuration
/// </summary>
public static class ValidatorConfiguration
{
    /// <summary>
    /// Adding app validation
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <returns></returns>
    public static IServiceCollection AddAppValidator(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation(opt => { opt.DisableDataAnnotationsValidation = true; });

        ValidatorsRegisterHelper.Register(services);

        services.AddSingleton(typeof(IModelValidator<>), typeof(ModelValidator<>));

        return services;
    }
}