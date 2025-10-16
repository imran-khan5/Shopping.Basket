using System.Collections.Concurrent;
using Shopping.Basket.Application.Abstractions;
using DomainEntity = Shopping.Basket.Domain.Entities;

namespace Shopping.Basket.Infrastructure.Repositories
{
    public class InMemoryBasketRepository : IBasketRepository
    {
        private readonly ConcurrentDictionary<Guid, DomainEntity.Basket> _baskets = new();

        public Task<DomainEntity.Basket?> Get(Guid id, CancellationToken ct)
            => Task.FromResult(_baskets.TryGetValue(id, out var b) ? b : null);

        public Task Save(DomainEntity.Basket basket, CancellationToken ct)
        {
            _baskets[basket.Id] = basket;
            return Task.CompletedTask;
        }
    }
}
