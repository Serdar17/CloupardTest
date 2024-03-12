using System.Linq.Expressions;
using Cloupard.Domain;
using Cloupard.Domain.Context;
using Cloupard.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cloupard.Infrastructure.Repository;

public class ProductRepository : IProductRepository
{
    private readonly IAppDbContext _context;

    public ProductRepository(IAppDbContext context)
    {
        _context = context;
    }

    public Task<IQueryable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Product>> GetAllAsync(Expression<Func<Product, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
    }

    public void Insert(Product model)
    {
        _context.Products.Add(model);
    }

    public void Update(Product model)
    {
        _context.Products.Update(model);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _context.Products
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }
}