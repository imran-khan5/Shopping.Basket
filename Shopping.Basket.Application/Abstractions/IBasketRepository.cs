namespace Shopping.Basket.Application.Abstractions;
using DomainEntity = Shopping.Basket.Domain.Entities;

public interface IBasketRepository
{
    Task<DomainEntity.Basket?> Get(Guid id, CancellationToken ct);
    Task Save(DomainEntity.Basket basket, CancellationToken ct);
}