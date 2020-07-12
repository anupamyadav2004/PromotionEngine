using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Services.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>()
        {
            new Product("A", 50m),
            new Product("B", 30m),
            new Product("C", 20m),
            new Product("D", 15m)
        };

        public Product Get(string productId)
        {
            return _products.Single(x => x.Id == productId.ToUpper());
        }
    }
}