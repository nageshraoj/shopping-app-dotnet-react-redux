using Catalog.Service.Models;

namespace Catalog.Service.Repositories;

public interface IProductRepository
{
    Task<bool> DeleteProductAsync(Guid id);
    Task<Product> GetProductAsync(Guid id);
    Task<IReadOnlyCollection<Product>> GetProductsAsync();
    Task<bool> NewProductAsync(Product product);
    Task<bool> UpdateProductAsync(Guid id, Product product);
}
