using Infra.Repository.Entities;
using Infra.Repository.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Context
{
    public class GoodHamburgerDbContext : DbContext
    {
        public DbSet<Orders> Orders => Set<Orders>();
        public DbSet<Products> Products => Set<Products>();
        public DbSet<OrdersProducts> OrdersProducts {  get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOrders> CustomerOrders { get; set; }

        public GoodHamburgerDbContext(DbContextOptions<GoodHamburgerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GoodHamburgerDbContext).Assembly);
              
            modelBuilder.ApplyConfiguration(new OrderMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new OrderProductsMapping());
            modelBuilder.ApplyConfiguration(new CustomerOrdersMapping());
            modelBuilder.ApplyConfiguration(new CustomerMapping());
        }
    }
}
