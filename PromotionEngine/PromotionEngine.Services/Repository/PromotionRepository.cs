using System.Collections.Generic;
using PromotionEngine.Services.Promotions;

namespace PromotionEngine.Services.Repository
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly IPromotionFactory _specialOfferFactory;

        public PromotionRepository(IPromotionFactory promotionFactory)
        {
            _specialOfferFactory = promotionFactory;
        }

        public IEnumerable<IPromotion> All()
        {
            return new List<IPromotion>
            {
                _specialOfferFactory.Create("A", 3, "A", 0.4m),
                _specialOfferFactory.Create("B", 2, "B", 0.5m),
                _specialOfferFactory.Create("C", 1, "D", 0.33m),
            };
        }
    }
}