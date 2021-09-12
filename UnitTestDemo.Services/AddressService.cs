using System;
using System.Threading.Tasks;
using UnitTestDemo.Data;

namespace UnitTestDemo.Services
{
    public interface IAddressService
    {
        Task AddAddressAsync(Address address);
    }

    public class AddressService : IAddressService
    {
        private readonly IDataContext _dataContext;
        public AddressService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAddressAsync(Address address)
        {
            if (address == null)
                throw new InvalidOperationException();

            await _dataContext.Address.AddAsync(address);
        }
    }
}
