using System;

namespace UnitTestDemo.Services
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow
        {
            get;
        }
    }

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow { get { return DateTime.UtcNow; } }
    }
}
