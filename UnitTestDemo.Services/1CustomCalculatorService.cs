namespace UnitTestDemo.Services
{
    public interface ICustomCalculatorService
    {
        int AddTwoNumbers(int x, int y);
        int Add(params int[] numbers);
        bool IsOdd(int value);
    }

    public class CustomCalculatorService : ICustomCalculatorService
    {
        public int AddTwoNumbers(int x, int y)
        {
            return x + y;
        }

        public int Add(params int[] numbers)
        {
            var total = 0;
            foreach (var number in numbers)
            {
                total += number;
            }
            return total;
        }

        public bool IsOdd(int value)
        {
            return value % 2 == 1;
        }
    }
}
