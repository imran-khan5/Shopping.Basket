using Shopping.Basket.Application.Commands;
using Shopping.Basket.Infrastructure.Repositories;

namespace Shopping.Basket.Tests
{
    [TestFixture]
    public class CreateBasketHandlerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CreateBasket_Creates_And_Persists()
        {
            // Arrange
            var repo = new InMemoryBasketRepository();
            var handler = new CreateBasketHandler(repo);

            // Act
            var id = await handler.Handle(new CreateBasket(), CancellationToken.None);
            var saved = await repo.Get(id, CancellationToken.None);

            // Assert
            Assert.IsNotNull(saved, "The Basket should be saved");
            Assert.AreEqual(id, saved!.Id, "Saved basket id should match and must returned id");
        }
    }
}