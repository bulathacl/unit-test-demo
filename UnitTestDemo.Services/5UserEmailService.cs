using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnitTestDemo.Data;
using UnitTestDemo.Services.ThridParty;

namespace UnitTestDemo.Services
{
    public interface IUserEmailService
    {
        Task SendUserEmailAsync(string emailMessage, int userId);
        string AppendEpochNowToUserId(int userId);
    }

    public class UserEmailService
    {
        private readonly IDataContext _dataContext;
        private readonly IEmailService _emailService;
        private readonly IDateTimeProvider _dateTimeProvider;
        public UserEmailService(
            IDataContext dataContext, 
            IEmailService emailService,
            IDateTimeProvider dateTimeProvider)
        {
            _dataContext = dataContext;
            _emailService = emailService;
            _dateTimeProvider = dateTimeProvider;
        }

        /// <summary>
        /// Email should also have user's first name, last name and address info 
        /// in addition to the content in the emailMessage parameter.
        /// </summary>
        /// <param name="emailMessage"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task SendUserEmailAsync(string emailMessage, int userId)
        {
            var user = await _dataContext.Users.Where(u => u.Id == userId)
                                .Include(u => u.Address)
                                .FirstOrDefaultAsync();
            if (user == null)
                throw new InvalidOperationException();

            await _emailService.SendEmailAsync(
                new SendEmailPayload
                {
                    EmailParameters =
                    new EmailParameters
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Address = user.Address != null ?
                        $"{user.Address.AddressLine1} {user.Address.AddressLine2}" : string.Empty,
                        Message = emailMessage
                    },
                    EmailTemplate = 1,
                    Recipient = user.Email
                });
        }

        //public string AppendEpochNowToUserId(int userId)
        //{
        //    DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        //    TimeSpan diff = DateTime.UtcNow - origin;
        //    var epoch = Math.Floor(diff.TotalMilliseconds);
        //    return $"{userId}_{epoch}";
        //}

        public string AppendEpochNowToUserId(int userId)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            //TimeSpan diff = DateTime.UtcNow - origin;
            TimeSpan diff = _dateTimeProvider.UtcNow - origin;
            var epoch = Math.Floor(diff.TotalMilliseconds);
            return $"{userId}_{epoch}";
        }
    }
}
