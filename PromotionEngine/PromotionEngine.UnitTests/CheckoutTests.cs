using System.Collections.Generic;
using Moq;
using PromotionEngine.Services;
using PromotionEngine.Services.Promotions;
using PromotionEngine.Services.Repository;
using Shouldly;
using Xunit;

namespace PromotionEngine.UnitTests
{
    public class CheckoutTests
    {
        readonly Mock<IPromotionRepository> _mockPromotionRepository = new Mock<IPromotionRepository>();
        private readonly Checkout _sut;

        public CheckoutTests()
        {
            _sut = new Checkout(_mockPromotionRepository.Object);
        }

        [Fact]
        public void AppliedPromotionIsSetCorrectly()
        {
            _mockPromotionRepository.Setup(x => x.All()).Returns(GetTestPromotions());

            var productC = new Product("C", 20m);
            var productD = new Product("D", 15m);

            _sut.AddProduct(productC);
            _sut.AddProduct(productD);

            var appliedPromotionInfo = _sut.ApplyPromotions();

            appliedPromotionInfo.Discount.ShouldBe(5);
        }

        [Fact]
        public void OnlyOnePromotionIsApplied()
        {
            _mockPromotionRepository.Setup(x => x.All()).Returns(GetTestPromotions());

            var productB = new Product("B", 30m);
            var productC = new Product("C", 20m);
            var productD = new Product("D", 15m);


            _sut.AddProduct(productB);
            _sut.AddProduct(productB);
            _sut.AddProduct(productC);
            _sut.AddProduct(productD);

            var appliedPromotionInfo = _sut.ApplyPromotions();

            appliedPromotionInfo.Discount.ShouldBe(15);
        }

        private static IEnumerable<Promotion> GetTestPromotions()
        {
            return new List<Promotion>()
            {
                new Promotion("A", 3, "A", 0.4m),
                new Promotion("B", 2, "B", 0.5m),
                new Promotion("C", 1, "D", 0.33m)
            };
        }
    }
}
