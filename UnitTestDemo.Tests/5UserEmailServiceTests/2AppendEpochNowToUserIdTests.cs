using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using UnitTestDemo.Data;
using UnitTestDemo.Services;
using UnitTestDemo.Services.ThridParty;
using Xunit;

namespace UnitTestDemo.Tests._5UserEmailServiceTests
{
    public class AppendEpochNowToUserIdTests
    {
        private IDataContext SetupDataContext()
        {
            DbContextOptions<DataContext> options;
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            options = builder.Options;
            var dbContext = new DataContext(options);
            return dbContext;
        }

        //[Fact]
        //public void AppendEpochNowToUser_WhenUserIdIsGIven_AppendEpoch()
        //{
        //    // Arrange your objects, creating and setting them up as necessary.
        //    var dataContext = SetupDataContext();
        //    var emailService = new Mock<IEmailService>();
        //    var dateTimeProvider = new Mock<IDateTimeProvider>();
        //    var service = new UserEmailService(dataContext, emailService.Object, dateTimeProvider.Object);
        //    DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        //    TimeSpan diff = DateTime.Now - origin;
        //    var epoch = Math.Floor(diff.TotalMilliseconds);
        //    // Act on an object.
        //    var text = service.AppendEpochNowToUserId(1);
        //    Assert.Equal($"1_{epoch}", text);
        //}

        [Fact]
        public void AppendEpochNowToUser_WhenUserIdIsGIven_AppendEpoch()
        {
            var date = new DateTime(2021, 10, 1, 13, 13, 13, 999);
            // Arrange your objects, creating and setting them up as necessary.
            var dataContext = SetupDataContext();
            var emailService = new Mock<IEmailService>();
            var dateTimeProvider = new Mock<IDateTimeProvider>();
            dateTimeProvider.Setup(x => x.UtcNow).Returns(date);

            var service = new UserEmailService(dataContext, emailService.Object, dateTimeProvider.Object);
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date - origin;
            var epoch = Math.Floor(diff.TotalMilliseconds);

            // Act on an object.
            var text = service.AppendEpochNowToUserId(1);
            Assert.Equal($"1_{epoch}", text);
        }
    }
}
