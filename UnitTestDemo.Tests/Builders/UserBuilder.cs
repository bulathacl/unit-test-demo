using UnitTestDemo.Data;

namespace UnitTestDemo.Tests.Builders
{
    public class UserBuilder
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private int _id;
        private Address _address;

        public UserBuilder()
        {
            // set default values
            _firstName = string.Empty;
            _lastName = string.Empty;
            _email = string.Empty;
            _id = 0;
            _address = null;
        }

        public UserBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public UserBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public UserBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public UserBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public UserBuilder WithAddress(Address address)
        {
            _address = address;
            return this;
        }

        public User Build()
        {
            return new User(_firstName, _lastName, _email, _address, _id);
        }
    }
}
