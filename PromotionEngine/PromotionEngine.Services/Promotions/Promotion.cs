using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Services.Promotions
{
    public class Promotion : IPromotion
    {
        public Promotion(string qualifyingProductId, int quantityToQualify, string discountProductId, decimal discountPercentage)
        {
            QualifyingProductId = qualifyingProductId;
            QuantityToQualify = quantityToQualify;
            DiscountProductId = discountProductId;
            DiscountPercentage = discountPercentage;
        }

        public decimal CalculateDiscount(IEnumerable<Product> products)
        {
            var qualifyingProductCount = products.Count(x => x.Id == QualifyingProductId);
            var qualifyingCount = qualifyingProductCount / QuantityToQualify;
            var discountableProducts = products.Where(x => x.Id == DiscountProductId).Take(qualifyingCount);
            var discount = Math.Round(discountableProducts.Sum(x => x.Price * DiscountPercentage));
            return discount;
        }

        public string QualifyingProductId { get; private set; }
        public int QuantityToQualify { get; private set; }
        public string DiscountProductId { get; private set; }
        public decimal DiscountPercentage { get; private set; }
    }
}