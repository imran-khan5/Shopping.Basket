using Shopping.Basket.Application.Abstractions;

namespace Shopping.Basket.Infrastructure.Services
{
    public class CatalogReadService : ICatalogReadService
    {
        private readonly List<Product> _products = new()
        {
            new Product("SKU-APPLE", "Apple", 0.50m),
            new Product("SKU-BANANA", "Banana", 0.30m),
            new Product("SKU-CHAIR", "Chair", 40.00m),
            new Product("SKU-DESK", "Desk", 120.00m),
            new Product("SKU-MUG", "Coffee Mug", 5.00m),
        };

        public Task<IEnumerable<Product>> GetAll(CancellationToken ct) => Task.FromResult(_products.AsEnumerable());
        public Task<Product?> GetBySku(string sku, CancellationToken ct)
            => Task.FromResult(_products.FirstOrDefault(p => p.Sku.Equals(sku, StringComparison.OrdinalIgnoreCase)));
    }
}
