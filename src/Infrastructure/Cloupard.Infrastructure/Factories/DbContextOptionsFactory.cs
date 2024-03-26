using Cloupard.Infrastructure.Context;
using HandmadeShop.Context.Settings;
using Microsoft.EntityFrameworkCore;

namespace Cloupard.Infrastructure.Factories;

public class DbContextOptionsFactory
{
    private const string MigrationProjectPrefix = "Cloupard.Infrastructure";

    public static DbContextOptions<AppDbContext> Create(string connStr, DbType dbType, bool detailedLogging = false)
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();

        Configure(connStr, dbType, detailedLogging).Invoke(builder);

        return builder.Options;
    }

    public static Action<DbContextOptionsBuilder> Configure(string connStr, DbType dbType, bool detailedLogging = false)
    {
        return builder =>
        {
            switch (dbType)
            {
                case DbType.MSSQL:
                    builder.UseSqlServer(connStr,
                        opts => opts
                            .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
                            .MigrationsHistoryTable("_migrations")
                            .MigrationsAssembly($"{MigrationProjectPrefix}")
                    );
                    break;
            }

            if (detailedLogging)
            {
                builder.EnableSensitiveDataLogging();
            }
        };
    }
}