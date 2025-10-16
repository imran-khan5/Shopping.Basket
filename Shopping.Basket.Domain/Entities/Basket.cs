
namespace Shopping.Basket.Domain.Entities
{
    public class Basket
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Currency { get; set; } = "GBP";
        public string Country { get; set; } = "GB";
        public string? DiscountCode { get; set; }
        public List<BasketItem> Items { get; } = new List<BasketItem>();

        public static Basket New() => new Basket();
    }
}
