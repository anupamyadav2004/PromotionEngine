namespace PromotionEngine.Services.Promotions
{
    public class PromotionFactory : IPromotionFactory
    {
        public IPromotion Create(string qualifyingProductId, int quantityToQualify, string discountProductId, decimal discountPercentage)
        {
            return new Promotion(qualifyingProductId, quantityToQualify, discountProductId, discountPercentage);
        }
    }
}