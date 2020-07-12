using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PromotionEngine.Services;
using PromotionEngine.Services.Promotions;
using Xunit;

namespace PromotionEngine.UnitTests
{
    public class ConsoleCheckoutTotalRendererTests
    {
        readonly TextWriter fakeConsoleOut = new StringWriter();
        readonly CheckoutTotal checkoutTotal = new CheckoutTotal();
        readonly ICheckoutTotalRenderer infoRenderer = new ConsoleCheckoutTotalRenderer();

        public ConsoleCheckoutTotalRendererTests()
        {
            checkoutTotal.PromotionApplied = new AppliedPromotionInfo();
            Console.SetOut(fakeConsoleOut);
        }

        [Fact]
        public void TotalAndSubtotalZeroNoOffers()
        {
            infoRenderer.Render(checkoutTotal);
            var expected = ExpectedOutput(new[] { "Subtotal: £0.00", "(No promotion available)", "Total: £0.00" });
            Assert.Equal(expected, fakeConsoleOut.ToString());
        }

        [Fact]
        public void SubtotalNonZero()
        {
            checkoutTotal.Subtotal = 0.65m;
            infoRenderer.Render(checkoutTotal);
            var expected = ExpectedOutput(new[] { "Subtotal: £0.65", "(No promotion available)", "Total: £0.00" });
            Assert.Equal(expected, fakeConsoleOut.ToString());
        }

        [Fact]
        public void TotalNonZero()
        {
            checkoutTotal.Total = 0.65m;
            infoRenderer.Render(checkoutTotal);
            var expected = ExpectedOutput(new[] { "Subtotal: £0.00", "(No promotion available)", "Total: £0.65" });
            Assert.Equal(expected, fakeConsoleOut.ToString());
        }

        [Fact]
        public void SingleOffer()
        {
            var promotionInfo = new AppliedPromotionInfo
            {
                Discount = 1.85m
            };
            checkoutTotal.PromotionApplied = promotionInfo;

            infoRenderer.Render(checkoutTotal);

            var expected = ExpectedOutput(new[] { "Subtotal: £0.00", "Promotion Applied: -£1.85", "Total: £0.00" });
            Assert.Equal(expected, fakeConsoleOut.ToString());
        }

        string ExpectedOutput(IEnumerable<string> expectedLines)
        {
            return expectedLines.Select(x => x + fakeConsoleOut.NewLine).Aggregate((x, y) => x + y);
        }
    }
}
