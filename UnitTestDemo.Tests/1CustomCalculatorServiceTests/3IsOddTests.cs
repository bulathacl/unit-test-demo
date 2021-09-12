using UnitTestDemo.Services;
using Xunit;

namespace UnitTestDemo.Tests.CustomCalculatorServiceTests
{
    public class IsOddTests
    {
        // Theories are tests which are only true for a particular set of data.
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        public void IsOdd_InputOddNumber_ReturnsTrue(int number)
        {
            var customCalculatorService = new CustomCalculatorService();

            var isOddNumber = customCalculatorService.IsOdd(number);

            Assert.True(isOddNumber);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        //[InlineData(5)]
        public void IsOdd_InputEvenNumber_ReturnsFalse(int number)
        {
            var customCalculatorService = new CustomCalculatorService();

            var isOddNumber = customCalculatorService.IsOdd(number);

            Assert.False(isOddNumber);
        }
    }
}
