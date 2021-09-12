using System.Diagnostics.CodeAnalysis;

namespace UnitTestDemo.Services.ThridParty
{
    //[ExcludeFromCodeCoverage]
    public class PostmarkConfiguration
    {
        public string ApiKey { get; set; }
        public string From { get; set; }
    }
}