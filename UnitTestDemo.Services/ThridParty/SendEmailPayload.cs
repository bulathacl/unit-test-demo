namespace UnitTestDemo.Services.ThridParty
{
    public class SendEmailPayload
    {
        public string From { get; set; }
        public string Recipient { get; set; }
        public int EmailTemplate { get; set; }
        public EmailParameters EmailParameters { get; set; }
    }

    public class EmailParameters
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Message { get; set; }
    }
}