using Cloupard.Domain.Context;
using Cloupard.Domain.Repository;
using Cloupard.Infrastructure.Context;
using Cloupard.Infrastructure.Factories;
using Cloupard.Infrastructure.Repository;
using Cloupard.Infrastructure.Settings;
using HandmadeShop.Context.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cloupard.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Common.Settings.Settings.Load<DbSettings>(DbSettings.SectionName, configuration);
        services.AddSingleton(settings);
        
        var dbInitOptionsDelegate = DbContextOptionsFactory.Configure(settings.ConnectionString, DbType.MSSQL, true);
        services.AddDbContextFactory<AppDbContext>(dbInitOptionsDelegate);
        
        services.AddDbContext<AppDbContext>(dbInitOptionsDelegate);
        
        services.AddScoped<IAppDbContext, AppDbContext>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddTransient(typeof(Lazy<>));
        
        return services;
    }
}