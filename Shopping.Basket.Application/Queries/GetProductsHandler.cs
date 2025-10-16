using Shopping.Basket.Application.Abstractions;

namespace Shopping.Basket.Application.Queries;

public class GetProductsHandler : IQueryHandler<GetProducts, IEnumerable<Product>>
{
    private readonly ICatalogReadService _catalog;
    public GetProductsHandler(ICatalogReadService catalog) => _catalog = catalog;

    public Task<IEnumerable<Product>> Handle(GetProducts query, CancellationToken ct)
        => _catalog.GetAll(ct);
}