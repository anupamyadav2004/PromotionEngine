using System.Linq;
using AutoFixture;
using Moq;
using PromotionEngine.Services.Promotions;
using PromotionEngine.Services.Repository;
using Shouldly;
using Xunit;

namespace PromotionEngine.UnitTests.Repository
{
    public class PromotionRepositoryTests
    {
        readonly Mock<IPromotionFactory> _mockPromotionFactory = new Mock<IPromotionFactory>();
        readonly IPromotionRepository _promotionRepository;
        private readonly Fixture _fixture;

        public PromotionRepositoryTests()
        {
            _promotionRepository = new PromotionRepository(_mockPromotionFactory.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public void ReturnsDiscountSpecialOfferCreatedByFactory()
        {
            var testPromotion = _fixture.Create<Promotion>();
            _mockPromotionFactory.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<decimal>()))
                .Returns(testPromotion);
            var promotions = _promotionRepository.All();

            testPromotion.ShouldBe(promotions.ElementAt<IPromotion>(0));
        }
    }
}
