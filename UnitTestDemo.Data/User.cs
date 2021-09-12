using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitTestDemo.Data
{
    //[ExcludeFromCodeCoverage]
    public class User : ISoftDelete, IAuditableEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset Created { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset? Modifided { get; set; }
        public bool IsDeleted { get; set; }
        public User() { }
        public User(string firstName, string lastName, string email, Address address, int id) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            Id = id;
        }
    }
}
