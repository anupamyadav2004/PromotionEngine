namespace PromotionEngine.Services.Promotions
{
    public interface IPromotionFactory
    {
        IPromotion Create(string qualifyingProductId, int quantityToQualify, string discountProductId, decimal discountPercentage);
    }
}