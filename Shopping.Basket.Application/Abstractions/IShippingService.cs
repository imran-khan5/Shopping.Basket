namespace Shopping.Basket.Application.Abstractions;

public interface IShippingService
{
    decimal CalculateShippingExVat(Domain.Entities.Basket basket, decimal goodsSubtotalAfterDiscounts);
}