using Microsoft.EntityFrameworkCore;

namespace UnitTestDemo.Data
{
    public interface IDataContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        int SaveChanges();
    }

    public class DataContext : DbContext, IDataContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
