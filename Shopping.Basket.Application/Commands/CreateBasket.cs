using Shopping.Basket.Application.Abstractions;

namespace Shopping.Basket.Application.Commands
{
    public record CreateBasket() : ICommand<Guid>;
}
