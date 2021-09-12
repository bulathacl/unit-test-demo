using UnitTestDemo.Services;
using Xunit;

namespace UnitTestDemo.Tests.CustomCalculatorServiceTests
{
    public class AddTests
    {
        [Fact]
        public void Add_EmptyArray_Return0()
        {
            // Arrange your objects, creating and setting them up as necessary.
            var customCalculatorService = new CustomCalculatorService();

            // Act on an object.
            var total = customCalculatorService.Add(new int[] { });

            // Assert that something is as expected.
            Assert.Equal(0, total);
        }

        [Fact]
        public void Add_ArrayWith4And9_Return13()
        {
            // Arrange your objects, creating and setting them up as necessary.
            var customCalculatorService = new CustomCalculatorService();

            // Act on an object.
            var total = customCalculatorService.Add(new int[] { 4, 9 });

            // Assert that something is as expected.
            Assert.Equal(13, total);
        }


        [Fact]
        public void Add_ArrayWith1And2And3_Return6()
        {
            // Arrange your objects, creating and setting them up as necessary.
            var customCalculatorService = new CustomCalculatorService();

            // Act on an object.
            var total = customCalculatorService.Add(new int[] { 1, 2, 3 });

            // Assert that something is as expected.
            Assert.Equal(6, total);
        }
    }
}
