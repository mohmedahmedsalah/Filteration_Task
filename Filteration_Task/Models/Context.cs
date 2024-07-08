using Microsoft.EntityFrameworkCore;

namespace Filteration_Task.Models
{
    public class Context:DbContext
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options)
       : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
