using Moq;
using PromotionEngine.Services;
using PromotionEngine.Services.Promotions;
using PromotionEngine.Services.Repository;
using Xunit;

namespace PromotionEngine.UnitTests
{
    public class PromotionEngineControllerTests
    {
        readonly Mock<IProductRepository> _productRepo = new Mock<IProductRepository>();
        readonly Mock<ICheckout> _checkout;
        readonly Mock<ICheckoutTotalRenderer> renderer = new Mock<ICheckoutTotalRenderer>();
        readonly CheckoutTotal _checkoutTotal = new CheckoutTotal();
        readonly PromotionEngineController _sut;
        readonly Product _product1 = new Product("A", 50m);
        readonly Product _product2 = new Product("B", 30m);
        readonly string[] _productIds;

        public PromotionEngineControllerTests()
        {
            _checkout = new Mock<ICheckout>();
            _sut = new PromotionEngineController(_productRepo.Object, _checkout.Object, renderer.Object);
            _productIds = new[] { _product1.Id, _product2.Id };
            _productRepo.Setup(x => x.Get(_product1.Id)).Returns(_product1);
            _productRepo.Setup(x => x.Get(_product2.Id)).Returns(_product2);
            _checkout.Setup(x => x.Total()).Returns(_checkoutTotal);
        }

        [Fact]
        public void ProductsRetrievedFromRepository()
        {
            _sut.Run(_productIds);
            _productRepo.Verify(x => x.Get(_product1.Id));
            _productRepo.Verify(x => x.Get(_product2.Id));
        }

        [Fact]
        public void ProductsAddedToCheckout()
        {
            _sut.Run(_productIds);
            _checkout.Verify(x => x.AddProduct(_product1));
            _checkout.Verify(x => x.AddProduct(_product2));
        }

        [Fact]
        public void TotalPriceCalculated()
        {
            _sut.Run(_productIds);
            _checkout.Verify(x => x.Total());
        }

        [Fact]
        public void BasketTotalRendered()
        {
            _sut.Run(_productIds);
            renderer.Verify(x => x.Render(_checkoutTotal));
        }
    }
}
