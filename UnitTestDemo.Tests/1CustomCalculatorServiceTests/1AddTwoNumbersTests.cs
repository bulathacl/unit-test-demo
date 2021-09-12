using UnitTestDemo.Services;
using Xunit;

namespace UnitTestDemo.Tests.CustomCalculatorServiceTests
{
    public class AddTwoNumbersTests
    {
        // Facts are tests which are always true. They test invariant conditions.
        [Fact]
        /// <summary>
        /// The name of your test should consist of three parts:
        ///
        /// The name of the method being tested.
        /// The scenario under which it's being tested.
        /// The expected behavior when the scenario is invoked.
        /// </summary>
        public void AddTwoNumbers_xIs4yIs5_Return9()
        {
            // Arrange your objects, creating and setting them up as necessary.
            var customCalculatorService = new CustomCalculatorService();

            // Act on an object.
            var total = customCalculatorService.AddTwoNumbers(4, 5);

            // Assert that something is as expected.
            Assert.Equal(9, total);
        }
    }
}
