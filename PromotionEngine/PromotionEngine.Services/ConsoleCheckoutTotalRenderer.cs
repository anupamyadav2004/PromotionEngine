using System;
using PromotionEngine.Services.Promotions;

namespace PromotionEngine.Services
{
    public class ConsoleCheckoutTotalRenderer : ICheckoutTotalRenderer
    {
        const string PriceFormat = "£{0:0.00}";

        public void Render(CheckoutTotal checkoutTotal)
        {
            Console.WriteLine("Subtotal: " + PriceFormat, checkoutTotal.Subtotal);
            RenderPromotions(checkoutTotal);
            Console.WriteLine("Total: " + PriceFormat, checkoutTotal.Total);
        }

        static void RenderPromotions(CheckoutTotal checkoutTotal)
        {
            var discount = checkoutTotal.PromotionApplied.Discount;
            if (discount == 0)
            {
                Console.WriteLine("(No promotion available)");
                return;
            }

            Console.WriteLine("Promotion Applied" + ": -" + PriceFormat, discount);
        }
    }
}