using System;
using System.Collections.Generic;
using System.Text;
using PromotionEngine.Services.Promotions;

namespace PromotionEngine.Services.Repository
{
    public interface IPromotionRepository
    {
        IEnumerable<IPromotion> All();
    }
}
