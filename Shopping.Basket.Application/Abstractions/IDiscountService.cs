namespace Shopping.Basket.Application.Abstractions;

public interface IDiscountService
{
    Task<DiscountValidation> Validate(string code, CancellationToken ct);
    Task<DiscountRule?> GetRule(string code, CancellationToken ct);
}