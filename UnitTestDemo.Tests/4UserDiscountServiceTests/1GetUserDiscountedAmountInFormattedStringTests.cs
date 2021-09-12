using UnitTestDemo.Services;
using Xunit;

namespace UnitTestDemo.Tests.UserDiscountServiceTests
{
    public class GetUserDiscountedAmountInFormattedStringTests
    {
        [Fact]
        public void GetUserDiscountedAmountInFormattedString_WhenAmountIsGivenWithDiscount_ReturnFinalAmountInFormattedString()
        {
            // Arrange your objects, creating and setting them up as necessary.
            var service = new UserDiscountService(new MathHelperService());

            // Act on an object.
            var value = service.GetUserDiscountedAmountInFormattedString(100, 50);

            // Assert that something is as expected.
            Assert.Equal("-$50.0", value);
        }

        //[Fact]
        //public void GetUserDiscountedAmountInFormattedString_WhenAmountIsGivenWithDiscountGreaterThan100_ReturnEmpytString()
        //{
        //    // Arrange your objects, creating and setting them up as necessary.
        //    var service = new UserDiscountService(new MathHelperService());

        //    // Act on an object.
        //    var value = service.GetUserDiscountedAmountInFormattedString(100, 100);

        //    // Assert that something is as expected.
        //    Assert.Equal(string.Empty, value);
        //}
    }
}
