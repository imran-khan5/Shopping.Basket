using Shopping.Basket.Application.Abstractions;

namespace Shopping.Basket.Application.Commands;

public class CreateBasketHandler : ICommandHandler<CreateBasket, Guid>
{
    private readonly IBasketRepository _repo;
    public CreateBasketHandler(IBasketRepository repo) => _repo = repo;

    public async Task<Guid> Handle(CreateBasket command, CancellationToken ct)
    {
        var basket = Domain.Entities.Basket.New();
        await _repo.Save(basket, ct);
        return basket.Id;
    }
}