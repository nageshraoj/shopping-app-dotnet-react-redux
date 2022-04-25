using Catalog.Service.Models;
using MongoDB.Driver;

namespace Catalog.Service.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> productCollection;
    private FilterDefinitionBuilder<Product> productFilter = Builders<Product>.Filter;

    public ProductRepository()
    {
        var dbClient = new MongoClient("mongodb://localhost:27017/temp");
        var database = dbClient.GetDatabase("products");
        productCollection = database.GetCollection<Product>("items");
    }

    public async Task<IReadOnlyCollection<Product>> GetProductsAsync()
    {
        return await productCollection.Find(productFilter.Empty).ToListAsync();
    }

    public async Task<Product> GetProductAsync(Guid id)
    {
        FilterDefinition<Product> itemFilter = productFilter.Eq(p => p.Id, id);
        return await productCollection.Find(itemFilter).FirstOrDefaultAsync();
    }

    public async Task<bool> NewProductAsync(Product product)
    {
        try
        {
            await productCollection.InsertOneAsync(product);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> UpdateProductAsync(Guid id, Product product)
    {
        try
        {
            FilterDefinition<Product> itemFilter = productFilter.Eq(p => p.Id, id);
            var existingProduct = await productCollection.FindAsync(itemFilter);
            if (existingProduct == null) return false;
            await productCollection.FindOneAndReplaceAsync(itemFilter, product);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        try
        {
            FilterDefinition<Product> itemFilter = productFilter.Eq(p => p.Id, id);
            var existingProduct = await productCollection.FindAsync(itemFilter);
            if (existingProduct == null) return false;
            await productCollection.FindOneAndDeleteAsync(itemFilter);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
