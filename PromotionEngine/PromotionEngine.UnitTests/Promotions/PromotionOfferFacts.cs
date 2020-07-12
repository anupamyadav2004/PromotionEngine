using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Services;
using PromotionEngine.Services.Promotions;
using Shouldly;
using Xunit;

namespace PromotionEngine.UnitTests.Promotions
{
    public class PromotionOfferFacts
    {
        readonly List<Product> _discountedTripleAProducts = new List<Product>();
        readonly IPromotion _tripleAPromotion;

        readonly List<Product> _discountedDoubleBProducts = new List<Product>();
        readonly IPromotion _doubleBPromotion;

        readonly List<Product> _discountedCombiProducts = new List<Product>();
        readonly IPromotion _mixProductPromotion;

        readonly List<Product> _noPromotionProducts = new List<Product>();

        public PromotionOfferFacts()
        {
            _tripleAPromotion = new Promotion("A", 3, "A", 0.4m);
            _doubleBPromotion = new Promotion("B", 2, "B", 0.5m);
            _mixProductPromotion = new Promotion("C", 1, "D", 0.33m);
            _noPromotionProducts.AddRange(Enumerable.Repeat(new Product("C", 20m), 3));
        }

        [Fact]
        public void NotEnoughItemsForOfferToApply()
        {
            var discount = _tripleAPromotion.CalculateDiscount(_noPromotionProducts);
            discount.ShouldBe(0m);
        }

        [Fact]
        public void ThreeAPromotionApplied()
        {
            _discountedTripleAProducts.AddRange(Enumerable.Repeat(new Product("A", 50m), 3));
            _discountedTripleAProducts.Add(new Product("B", 30m));
            var discount = _tripleAPromotion.CalculateDiscount(_discountedTripleAProducts);
            discount.ShouldBe(20);
        }

        [Fact]
        public void TwoBPromotionApplied()
        {
            _discountedDoubleBProducts.AddRange(Enumerable.Repeat(new Product("B", 30m), 2));
            var discount = _doubleBPromotion.CalculateDiscount(_discountedDoubleBProducts);
            discount.ShouldBe(15);
        }

        [Fact]
        public void MixProductPromotionApplied()
        {
            _discountedCombiProducts.Add(new Product("C", 20m));
            _discountedCombiProducts.Add(new Product("D", 15m));
            var discount = _mixProductPromotion.CalculateDiscount(_discountedCombiProducts);
            discount.ShouldBe(5);
        }

        [Fact]
        public void MultiplePromotionOfSameTypeApplies()
        {
            _discountedTripleAProducts.AddRange(Enumerable.Repeat(new Product("A", 50m), 6));
            var discount = _tripleAPromotion.CalculateDiscount(_discountedTripleAProducts);
            discount.ShouldBe(40);
        }
    }
}
