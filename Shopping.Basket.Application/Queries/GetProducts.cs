using Shopping.Basket.Application.Abstractions;

namespace Shopping.Basket.Application.Queries
{
    public record GetProducts() : IQuery<IEnumerable<Product>>;
}
