using System.Collections.Generic;
using PromotionEngine.Services.Promotions;
using PromotionEngine.Services.Repository;

namespace PromotionEngine.Services
{
    public class PromotionEngineController : IPromotionEngineController
    {
        readonly IProductRepository _productRepository;
        readonly ICheckout _checkout;

        public PromotionEngineController(IProductRepository productRepository, ICheckout checkout)
        {
            _productRepository = productRepository;
            _checkout = checkout;
        }

        public void Run(IEnumerable<string> productIds)
        {
            foreach (var productId in productIds)
            {
                var product = _productRepository.Get(productId);
                _checkout.AddProduct(product);
            }
            var checkoutTotal = _checkout.Total();
        }
    }
}