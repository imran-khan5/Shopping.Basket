namespace Shopping.Basket.Application.Abstractions;

public record PricingBreakdown(
    string Currency,
    decimal ItemsSubtotalExVat,
    decimal DiscountFromCodeExVat,
    decimal ShippingExVat,
    decimal VatOnItems,
    decimal VatOnShipping,
    decimal TotalExVat,
    decimal TotalIncVat,
    string? DiscountCode,
    decimal VatRatePercent
);