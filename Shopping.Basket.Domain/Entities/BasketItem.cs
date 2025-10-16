
namespace Shopping.Basket.Domain.Entities
{
    public class BasketItem
    {
        public string Sku { get; private set; }
        public string Name { get; private set; }
        public decimal UnitPriceExVat { get; private set; }
        public int Quantity { get; private set; }
        public bool IsDiscounted { get; private set; }
        public decimal? DiscountedUnitPriceExVat { get; private set; }

        public static BasketItem Create(string sku, string name, decimal unitPriceExVat, int qty)
        {
            return new BasketItem
            {
                Sku = sku,
                Name = name,
                UnitPriceExVat = unitPriceExVat,
                Quantity = qty,
                IsDiscounted = false,
                DiscountedUnitPriceExVat = null
            };
        }

        public static BasketItem CreateDiscounted(string sku, string name, decimal discountedUnitPriceExVat, int qty)
        {
            return new BasketItem
            {
                Sku = sku,
                Name = name,
                UnitPriceExVat = discountedUnitPriceExVat, // mirrors your original
                Quantity = qty,
                IsDiscounted = true,
                DiscountedUnitPriceExVat = discountedUnitPriceExVat
            };
        }

        public decimal LinePriceExVat =>
            ((IsDiscounted && DiscountedUnitPriceExVat.HasValue) ? DiscountedUnitPriceExVat.Value : UnitPriceExVat) *
            Quantity;

    }
}
