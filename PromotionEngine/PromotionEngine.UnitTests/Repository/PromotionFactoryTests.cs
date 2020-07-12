using PromotionEngine.Services.Promotions;
using Shouldly;
using Xunit;

namespace PromotionEngine.UnitTests.Repository
{
    public class PromotionFactoryTests
    {
        [Fact]
        public void InstanceCreatedWithCorrectParameters()
        {
            const string qualifyingProductId = "qualifyingProductId";
            const int quantityToQualify = 10;
            const string discountProductId = "discountProductId";
            const decimal discountPercentage = 0.5m;
            IPromotionFactory factory = new PromotionFactory();

            var instance = factory.Create(qualifyingProductId, quantityToQualify, discountProductId, discountPercentage);

            var concrete = Assert.IsAssignableFrom<Promotion>(instance);

            qualifyingProductId.ShouldBe(concrete.QualifyingProductId);
            quantityToQualify.ShouldBe(concrete.QuantityToQualify);
            discountProductId.ShouldBe(concrete.DiscountProductId);
            discountPercentage.ShouldBe(concrete.DiscountPercentage);
        }
    }
}