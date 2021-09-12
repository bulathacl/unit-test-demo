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
    }

    public class UserEmailService
    {
        private readonly IDataContext _dataContext;
        private readonly IEmailService _emailService;
        public UserEmailService(IDataContext dataContext, IEmailService emailService)
        {
            _dataContext = dataContext;
            _emailService = emailService;
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
            //await _emailService.SendEmailAsync(5);
        }
    }
}
