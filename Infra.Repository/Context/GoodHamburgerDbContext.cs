using Infra.Repository.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Context
{
    public class GoodHamburgerDbContext : DbContext
    {
        public DbSet<Entities.Orders> Orders => Set<Entities.Orders>();
        public DbSet<Entities.Products> Products => Set<Entities.Products>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GoodHamburgerDbContext).Assembly);
            modelBuilder.ApplyConfiguration(new OrderMapping());

            modelBuilder.Entity<Entities.Orders>().
                HasMany(a => a.Products);
        }
    }
}
