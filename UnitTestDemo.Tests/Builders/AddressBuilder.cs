using UnitTestDemo.Data;

namespace UnitTestDemo.Tests.Builders
{
    public class AddressBuilder
    {
        private string _addressLine1;
        private string _addressLine2;

        public AddressBuilder()
        {
            // set default values
            _addressLine1 = string.Empty;
            _addressLine2 = string.Empty;
        }

        public AddressBuilder WithAddressLine1(string addressLine1)
        {
            _addressLine1 = addressLine1;
            return this;
        }

        public AddressBuilder WithAddressLine2(string addressLine2)
        {
            _addressLine2 = addressLine2;
            return this;
        }

        public Address Build()
        {
            return new Address(_addressLine1, _addressLine2);
        }
    }
}
