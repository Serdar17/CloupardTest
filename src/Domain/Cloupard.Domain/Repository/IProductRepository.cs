using System.Linq.Expressions;

namespace Cloupard.Domain.Repository;

public interface IProductRepository
{
    Task<IQueryable<Product>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IQueryable<Product>> GetAllAsync(Expression<Func<Product, bool>> predicate);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Insert(Product model);
    void Update(Product model);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}