using Cloupard.Domain.Context;
using Cloupard.Domain.Repository;

namespace Cloupard.Infrastructure.Context;

public class UnitOfWork : IUnitOfWork
{
    private readonly IAppDbContext _context;
    private readonly Lazy<IProductRepository> _productRepository;
    
    public UnitOfWork(
        IAppDbContext context, 
        Lazy<IProductRepository> productRepository)
    {
        _context = context;
        _productRepository = productRepository;
    }

    public IProductRepository ProductRepository => _productRepository.Value;

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveAsync(cancellationToken);
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}