namespace UnitTestDemo.Services
{
    public interface IUserDiscountService
    {
        string GetUserDiscountedAmountInFormattedString(decimal totalAmount, decimal discountPercentage);
    }
    public class UserDiscountService : IUserDiscountService
    {
        private readonly IMathHelperService _mathHelperService;
        public UserDiscountService(IMathHelperService mathHelperService)
        {
            _mathHelperService = mathHelperService;
        }
        public string GetUserDiscountedAmountInFormattedString(decimal totalAmount, decimal discountPercentage)
        {
            var discount = discountPercentage < 100 ? (totalAmount * (discountPercentage / 100)) : totalAmount;
            return discount == totalAmount ? string.Empty : _mathHelperService.GetMinusDollarString(discount);
        }
    }
}
