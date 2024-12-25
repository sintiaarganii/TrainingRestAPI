using Microsoft.EntityFrameworkCore;
using Training2.Models.DB;

namespace Training2.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Customer> Customers { get; set; }

    }
}
