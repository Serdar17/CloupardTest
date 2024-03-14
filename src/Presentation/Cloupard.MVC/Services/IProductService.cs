using Cloupard.MVC.Models;

namespace Cloupard.MVC.Services;

public interface IProductService
{
    Task<ProductModel?> GetProductByIdAsync(Guid productId);
    Task<IEnumerable<ProductModel>> GetAllProductsAsync(string? searchValue);
    Task CreateProductAsync(ProductModel model);
    Task UpdateProductAsync(ProductModel model);
    Task DeleteProductAsync(Guid productId);
}