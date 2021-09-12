using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using UnitTestDemo.Data;
using UnitTestDemo.Services;
using UnitTestDemo.Tests.Builders;
using Xunit;

namespace UnitTestDemo.Tests.UserServiceTests
{
    public class AddUserAsyncTests
    {
        private IDataContext SetupDataContext()
        {
            DbContextOptions<DataContext> options;
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            options = builder.Options;
            return new DataContext(options);
        }

        [Fact]
        public async Task AddUserAsync_WhenUserDetailsAreGiven_UserIsAddedToDB()
        {
            var dbContext = SetupDataContext();
            var userService = new UserService(dbContext);
            await userService.AddUserAsync(
                new User
                {
                    FirstName = "Chandula",
                    LastName = "Bulathsinhala",
                    Email = "chandula.b@aeturnum.com",
                    Address = new Address
                    {
                        AddressLine1 = "Test1",
                        AddressLine2 = "Test2"
                    }
                });

            //await userService.AddUserAsync(
            //    new UserBuilder()
            //    .WithFirstName("Chandula")
            //    .WithLastName("Bulathsinhala")
            //    .WithEmail("chandula.b@aeturnum.com")
            //    .WithAddress(new AddressBuilder()
            //                    .WithAddressLine1("Test1")
            //                    .WithAddressLine2("Test2")
            //                    .Build())
            //    .Build());
            
            var userObj = await dbContext.Users.FirstOrDefaultAsync(u => u.FirstName == "Chandula");
            Assert.NotNull(userObj);
        }

        [Fact]
        public async Task AddUserAsync_WhenUserObjIsNull_ExceptionIsThrown()
        {
            var dbContext = SetupDataContext();
            var userService = new UserService(dbContext);
            Func<Task> act = () => userService.AddUserAsync(null);
            await Assert.ThrowsAsync<InvalidOperationException>(act);
        }

        [Fact]
        public async Task AddUserAsync_WhenUserObjAddressIsNull_ExceptionIsThrown()
        {
            var dbContext = SetupDataContext();
            var userService = new UserService(dbContext);
            Func<Task> act = () => userService.AddUserAsync(
                new UserBuilder()
                .WithFirstName("Chandula")
                .WithLastName("Bulathsinhala")
                .WithEmail("chandula.b@aeturnum.com")
                .Build());
            await Assert.ThrowsAsync<InvalidOperationException>(act);
        }
    }
}
