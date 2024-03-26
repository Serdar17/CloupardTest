using Cloupard.Domain;
using Cloupard.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cloupard.Infrastructure.Setup;

public static class DbSeeder
{
    private static IServiceScope ServiceScope(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetService<IServiceScopeFactory>()!.CreateScope();
    }

    private static AppDbContext DbContext(IServiceProvider serviceProvider)
    {
        return ServiceScope(serviceProvider)
            .ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext();
    }

    public static void Execute(IServiceProvider serviceProvider)
    {
        Task.Run(async () =>
            {
                await AddDemoData(serviceProvider);
            })
            .GetAwaiter()
            .GetResult();
    }

    private static async Task AddDemoData(IServiceProvider serviceProvider)
    {
        using var scope = ServiceScope(serviceProvider);
        if (scope == null)
            return;

        await using var context = DbContext(serviceProvider);

        if (await context.Products.AnyAsync())
            return;

        await context.Products.AddRangeAsync(GetProducts());

        await context.SaveChangesAsync();
    }
    
    private static ICollection<Product> GetProducts()
    {
        var products = new List<Product>();
            
        products.Add(new Product {Name = "Laptop", Description = "A new laptop with a modern design"});
        products.Add(new Product {Name = "Smartphone", Description = "A smartphone with a powerful processor"});
        products.Add(new Product {Name = "SmartWatches", Description = "The most necessary product for your life"});
        return products;
    }

}