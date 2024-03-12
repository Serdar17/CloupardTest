using Cloupard.Domain.Repository;

namespace Cloupard.Domain.Context;

public interface IUnitOfWork : IDisposable
{
    public IProductRepository ProductRepository { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}