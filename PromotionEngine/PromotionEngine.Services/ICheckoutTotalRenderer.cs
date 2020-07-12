using PromotionEngine.Services.Promotions;

namespace PromotionEngine.Services
{
    public interface ICheckoutTotalRenderer
    {
        void Render(CheckoutTotal checkoutTotal);
    }
}