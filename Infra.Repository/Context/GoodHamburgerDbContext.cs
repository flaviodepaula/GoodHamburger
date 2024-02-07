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

        public GoodHamburgerDbContext(DbContextOptions<GoodHamburgerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GoodHamburgerDbContext).Assembly);

            modelBuilder.Entity<OrdersProducts>().HasKey(x => new { x.OrderId, x.ProductId });

            modelBuilder.ApplyConfiguration(new OrderMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());

            modelBuilder.Entity<OrdersProducts>()
                .HasOne(x => x.Order)
                .WithMany(y => y.ProductsOnOrder)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<OrdersProducts>()
                .HasOne(x => x.Product)
                .WithMany(y=> y.OrdersProducts)
                .HasForeignKey(x => x.ProductId);

            //complex type in EF8.
            modelBuilder.Entity<Customer>().ComplexProperty(a => a.Address, a=> a.IsRequired());
        }
    }
}
