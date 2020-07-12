namespace PromotionEngine.Services.Promotions
{
    public interface ICheckout
    {
        void AddProduct(Product product);
        CheckoutTotal Total();
        AppliedPromotionInfo ApplyPromotions();
    }
}