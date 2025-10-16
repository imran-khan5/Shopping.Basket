using Shopping.Basket.Application.Queries;
using Shopping.Basket.Infrastructure.Services;

namespace Shopping.Basket.Tests
{
    [TestFixture]
    public class GetProductsHandlerTests
    {
        [Test]
        public async Task GetProducts_Returns_DummyData_Seeded_List()
        {
            // Arrange
            var svc = new CatalogReadService();
            var handler = new GetProductsHandler(svc);

            // Act
            var products = await handler.Handle(new GetProducts(), CancellationToken.None);

            // Assert
            Assert.IsNotNull(products);
            Assert.AreEqual(5, products.Count(), "CatalogReadService must seeds 5 products");
            Assert.IsTrue(products.Any(p => p.Sku == "SKU-APPLE"), "List must contain SKU-APPLE");
        }
    }
}
