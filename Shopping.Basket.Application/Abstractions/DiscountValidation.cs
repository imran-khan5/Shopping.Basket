namespace Shopping.Basket.Application.Abstractions;

public record DiscountValidation(bool IsValid, string? Reason = null);