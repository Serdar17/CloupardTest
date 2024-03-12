using Cloupard.Common.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Cloupard.Api.Configuration;

public static class ControllerConfiguration
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddAppController(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddNewtonsoftJson(options => options.SerializerSettings.SetDefaultSettings())
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                    new BadRequestObjectResult(context.ModelState.ToErrorResponse());
            });

        return services;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder UseAppController(this IEndpointRouteBuilder app)
    {
        app.MapControllers();

        return app;
    }
}