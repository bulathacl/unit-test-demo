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
    public class GetUserByIdAsyncTests
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

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        public async Task GetUserByIdAsync_WhenValidUserIdIsGiven_ReturnUser(int userId)
        {
            var dbContext = await SetupDataContextAsync();
            var userService = new UserService(dbContext);
            var user = await userService.GetUserByIdAsync(userId);
            Assert.NotNull(user);
            Assert.Equal(userId, user.Id);
        }

        [Fact]
        public async Task GetUserByIdAsync_WhenInvalidUserIdIsGiven_ReturnNull()
        {
            var dbContext = await SetupDataContextAsync();
            var userService = new UserService(dbContext);
            var user = await userService.GetUserByIdAsync(6);
            Assert.Null(user);
        }
    }
}
