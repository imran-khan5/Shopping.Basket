namespace Shopping.Basket.Application.Abstractions;

public interface IPricingService
{
    PricingBreakdown Calculate(Domain.Entities.Basket basket);
}