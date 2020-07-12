using Microsoft.Extensions.DependencyInjection;
using PromotionEngine.Services.Promotions;
using PromotionEngine.Services.Repository;

namespace PromotionEngine.Services
{
    public static class PromotionEngineModule
    {
        public static ServiceProvider InitializeServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton<IProductRepository, ProductRepository>()
                .AddSingleton<ICheckout, Checkout>()
                .AddSingleton<IPromotion, Promotion>()
                .AddSingleton<IPromotionFactory, PromotionFactory>()
                .AddSingleton<IPromotionEngineController, PromotionEngineController>()
                .AddSingleton<IPromotionRepository, PromotionRepository>()
                .AddSingleton<ICheckoutTotalRenderer, ConsoleCheckoutTotalRenderer>()
                .BuildServiceProvider();
        }
    }
}
