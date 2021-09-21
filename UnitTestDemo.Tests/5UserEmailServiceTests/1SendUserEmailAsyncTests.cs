using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTestDemo.Data;
using UnitTestDemo.Services;
using UnitTestDemo.Services.ThridParty;
using UnitTestDemo.Tests.Builders;
using Xunit;

namespace UnitTestDemo.Tests.UserEmailServiceTests
{
    public class SendUserEmailAsyncTests
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
        public async Task SendUserEmailAsync_WhenValidIdOfUserWithAddressIsGIven_SendEmail()
        {
            // Arrange your objects, creating and setting them up as necessary.
            var dataContext = await SetupDataContextAsync();
            var emailService = new Mock<IEmailService>();
            var dateTimeProvider = new Mock<IDateTimeProvider>();
            dateTimeProvider.Setup(x => x.UtcNow).Returns(DateTime.UtcNow);
            var service = new UserEmailService(dataContext, emailService.Object, dateTimeProvider.Object);

            // Act on an object.
            await service.SendUserEmailAsync("TestMsg", 3);

            // Assert that something is as expected.
            emailService.Verify(x => x.SendEmailAsync(It.IsAny<SendEmailPayload>()), Times.Once());

            //If you want to be more specific with the verification
            //emailService.Verify(x => x.SendEmailAsync(9), Times.Once());
        }

        [Fact]
        public async Task SendUserEmailAsync_WhenValidIdOfUserWithoutAddressIsGIven_SendEmail()
        {
            // Arrange your objects, creating and setting them up as necessary.
            var dataContext = await SetupDataContextAsync();
            var emailService = new Mock<IEmailService>();
            var dateTimeProvider = new Mock<IDateTimeProvider>();
            dateTimeProvider.Setup(x => x.UtcNow).Returns(DateTime.UtcNow);
            var service = new UserEmailService(dataContext, emailService.Object, dateTimeProvider.Object);

            // Act on an object.
            await service.SendUserEmailAsync("TestMsg", 4);

            // Assert that something is as expected.
            emailService.Verify(x => x.SendEmailAsync(It.IsAny<SendEmailPayload>()), Times.Once());
        }
    }
}
