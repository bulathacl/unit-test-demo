using UnitTestDemo.Services;
using Xunit;

namespace UnitTestDemo.Tests.MathHelperServiceTests
{
    public class MathHelperServiceTests
    {
        [Theory]
        [InlineData(45.55, "-$45.55")]
        //[InlineData(50.5, "-$50.50")]
        // Although through reports just one test case gives full coverage you can see that there are some scenarios which might still not be covered.
        public void GetMinusDollarString_WhenAmountIsGive_ReturnFormattedString(decimal amount, string str)
        {
            // Arrange your objects, creating and setting them up as necessary.
            var service = new MathHelperService();

            // Act on an object.
            var value = service.GetMinusDollarString(amount);

            // Assert that something is as expected.
            Assert.Equal(str, value);
        }
    }
}
