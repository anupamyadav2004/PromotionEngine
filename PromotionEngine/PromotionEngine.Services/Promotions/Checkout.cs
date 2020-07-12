using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Services.Repository;

namespace PromotionEngine.Services.Promotions
{
    public class Checkout : ICheckout
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IList<Product> _products;

        public Checkout(IPromotionRepository promotionRepository)
        {
            this._promotionRepository = promotionRepository;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public CheckoutTotal Total()
        {
            var subtotal = CalculateSubtotal();
            var promotionApplied = ApplyPromotions();
            var total = CalculateTotal(subtotal, promotionApplied.Discount);
            return new CheckoutTotal
            {
                Subtotal = subtotal,
                PromotionApplied = promotionApplied,
                Total = total
            };
        }

        private decimal CalculateSubtotal()
        {
            return _products.Sum(x => x.Price);
        }

        private static decimal CalculateTotal(decimal subtotal, decimal totalDiscount)
        {
            return subtotal - totalDiscount;
        }

        public AppliedPromotionInfo ApplyPromotions()
        {
            var promotions = _promotionRepository.All();
            var appliedPromotionInfo = new AppliedPromotionInfo();
            foreach (var currentPromotion in promotions)
            {
                var discount = currentPromotion.CalculateDiscount(_products);
                if (discount > 0)
                {
                    appliedPromotionInfo.Discount = discount;
                    return appliedPromotionInfo;
                }
            }
            return appliedPromotionInfo;
        }
    }
}