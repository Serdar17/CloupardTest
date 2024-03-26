using Cloupard.Infrastructure.Context;
using HandmadeShop.Context.Settings;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Cloupard.Infrastructure.Factories;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var provider = (args?[0] ?? $"{DbType.MSSQL}").ToLower();

        var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.context.json"), false)
            .Build();

        var connStr = configuration.GetConnectionString(provider);

        DbType dbType;
        if (provider.Equals($"{DbType.MSSQL}".ToLower()))
            dbType = DbType.MSSQL;
        else
            throw new Exception($"Unsupported provider: {provider}");

        var options = DbContextOptionsFactory.Create(connStr, dbType, false);
        var factory = new DbContextFactory(options);
        var context = factory.Create();

        return context;
    }
}