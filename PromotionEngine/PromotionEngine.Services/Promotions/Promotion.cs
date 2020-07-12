using System.Collections.Generic;

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
            return 0m;
        }

        public string QualifyingProductId { get; private set; }
        public int QuantityToQualify { get; private set; }
        public string DiscountProductId { get; private set; }
        public decimal DiscountPercentage { get; private set; }
    }
}