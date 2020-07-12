using System.Collections.Generic;

namespace PromotionEngine.Services.Promotions
{
    public interface IPromotion
    {
        decimal CalculateDiscount(IEnumerable<Product> products);
    }
}
