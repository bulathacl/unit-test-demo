using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTestDemo.Data;
using UnitTestDemo.Services;
using UnitTestDemo.Tests.Builders;
using Xunit;

namespace UnitTestDemo.Tests.UserServiceTests
{
    public class GetUserByIdWithAddressAsyncTests
    {
        private async Task<IDataContext> SetupDataContextAsync()
        {
            DbContextOptions<DataContext> options;
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            options = builder.Options;
            var dbContext = new DataContext(options);
            await dbContext.Users.AddRangeAsync(new List<User> {
                new UserBuilder()
                .WithId(3)
                .WithFirstName("Chandula")
                .WithLastName("Bulathsinhala")
                .WithEmail("chandula.b@aeturnum.com")
                .WithAddress(new AddressBuilder()
                                .WithAddressLine1("Test1")
                                .WithAddressLine2("Test2")
                                .Build())
                .Build(),
                new UserBuilder()
                .WithId(4)
                .WithFirstName("Ross")
                .WithLastName("Geller")
                .WithEmail("ross.g@aeturnum.com")
                .Build()
            });
            await dbContext.SaveChangesAsync();
            return dbContext;
        }

        [Fact]
        public async Task GetUserByIdWithAddressAsync_WhenValidUserIdOfUserWithAddressIsGiven_ReturnUserWithAddress()
        {
            var dbContext = await SetupDataContextAsync();
            var userService = new UserService(dbContext);
            var user = await userService.GetUserByIdWithAddressAsync(3);
            Assert.NotNull(user);
            Assert.NotNull(user.Address);
            Assert.Equal(3, user.Id);
        }

        [Fact]
        public async Task GetUserByIdWithAddressAsync_WhenValidUserIdOfUserWithoutAddressIsGiven_ReturnUserOnly()
        {
            var dbContext = await SetupDataContextAsync();
            var userService = new UserService(dbContext);
            var user = await userService.GetUserByIdWithAddressAsync(4);
            Assert.NotNull(user);
            Assert.Null(user.Address);
            Assert.Equal(4, user.Id);
        }

        [Fact]
        public async Task GetUserByIdWithAddressAsync_WhenInvalidUserIdIsGiven_ReturnNull()
        {
            var dbContext = await SetupDataContextAsync();
            var userService = new UserService(dbContext);
            var user = await userService.GetUserByIdWithAddressAsync(6);
            Assert.Null(user);
        }
    }
}
