using System.Collections.Generic;
using PromotionEngine.Services.Repository;
using Shouldly;
using Xunit;

namespace PromotionEngine.UnitTests.Repository
{
    public class ProductRepositoryTests
    {
        readonly IProductRepository _productRepository = new ProductRepository();

        [Theory]
        [MemberData(nameof(Basket))]
        public void ReturnsProduct(string id, decimal price)
        {
            var product = _productRepository.Get(id);

            id.ShouldBe(product.Id);
            price.ShouldBe(product.Price);
        }

        public static IEnumerable<object[]> Basket
        {
            get
            {
                yield return new object[] { "A", 50m };
                yield return new object[] { "B", 30m };
                yield return new object[] { "C", 20m };
                yield return new object[] { "D", 15m };
            }
        }
    }
}
