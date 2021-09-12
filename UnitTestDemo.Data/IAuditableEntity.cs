using System;

namespace UnitTestDemo.Data
{
    public interface IAuditableEntity
    {
        Guid CreatedBy { get; set; }
        DateTimeOffset Created { get; set; }
        Guid ModifiedBy { get; set; }
        DateTimeOffset? Modifided { get; set; }
    }
}
