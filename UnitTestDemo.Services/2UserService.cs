using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using UnitTestDemo.Data;

namespace UnitTestDemo.Services
{
    public interface IUserService
    {
        Task AddUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByIdWithAddressAsync(int id);
    }

    public class UserService : IUserService
    {
        private readonly IDataContext _dataContext;
        public UserService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddUserAsync(User user)
        {
            if (user == null || user.Address == null)
                throw new InvalidOperationException();

            await _dataContext.Users.AddAsync(user);
            _dataContext.SaveChanges();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByIdWithAddressAsync(int id)
        {
            var asd = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            return await _dataContext.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
