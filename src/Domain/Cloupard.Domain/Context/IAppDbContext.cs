using Microsoft.EntityFrameworkCore;

namespace Cloupard.Domain.Context;

public interface IAppDbContext : IDisposable
{
    DbSet<Product> Products { get; }
    Task SaveAsync(CancellationToken cancellationToken = default);
}