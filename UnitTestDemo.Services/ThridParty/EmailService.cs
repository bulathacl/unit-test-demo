using PostmarkDotNet;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace UnitTestDemo.Services.ThridParty
{
    public interface IEmailService
    {
        Task SendEmailAsync(SendEmailPayload emailPayload);
        Task SendEmailAsync(int id);
    }

    //[ExcludeFromCodeCoverage]
    public class PostmarkEmailService : IEmailService
    {
        private readonly PostmarkConfiguration _postmarkConfiguration;
        private readonly PostmarkClient _postmarkClient;

        public PostmarkEmailService(PostmarkConfiguration postmarkConfiguration)
        {
            _postmarkConfiguration = postmarkConfiguration;
            _postmarkClient = new PostmarkClient(_postmarkConfiguration.ApiKey);
        }

        public async Task SendEmailAsync(SendEmailPayload emailPayload)
        {
            await _postmarkClient.SendEmailWithTemplateAsync(new TemplatedPostmarkMessage
            {
                To = emailPayload.Recipient,
                From = _postmarkConfiguration.From,
                TemplateId = emailPayload.EmailTemplate,
                TemplateModel = emailPayload.EmailParameters
            });
        }
        public async Task SendEmailAsync(int id)
        {
            await Task.CompletedTask;
        }
    }
}
