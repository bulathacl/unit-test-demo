using System;

namespace UnitTestDemo.Data
{
    //[ExcludeFromCodeCoverage]
    public class Address : ISoftDelete, IAuditableEntity
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset Created { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset? Modifided { get; set; }
        public Address() { }
        public Address(string addressLine1, string addressLine2) : this()
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
        }
    }
}
