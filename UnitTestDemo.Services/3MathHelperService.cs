namespace UnitTestDemo.Services
{
    public interface IMathHelperService
    {
        string GetMinusDollarString(decimal amount);
    }
    public class MathHelperService : IMathHelperService
    {
        public string GetMinusDollarString(decimal amount)
        {
            return $"-${amount}";
        }
    }
}
