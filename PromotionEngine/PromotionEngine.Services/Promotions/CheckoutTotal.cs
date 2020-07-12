namespace PromotionEngine.Services.Promotions
{
    public class CheckoutTotal
    {
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public AppliedPromotionInfo PromotionApplied { get; set; }
    }
}