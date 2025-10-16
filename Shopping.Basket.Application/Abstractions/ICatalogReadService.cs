namespace Shopping.Basket.Application.Abstractions;

public interface ICatalogReadService
{
    Task<IEnumerable<Product>> GetAll(CancellationToken ct);
    Task<Product?> GetBySku(string sku, CancellationToken ct);
}