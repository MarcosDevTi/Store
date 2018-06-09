using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;

namespace Store.Infra.Data.Repositories
{
    public class StoreContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
    }
}
