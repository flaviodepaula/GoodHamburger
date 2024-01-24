using Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Repository
{
    [ExcludeFromCodeCoverage]
    public class GoodHamburgerSqlContextFactory : IDesignTimeDbContextFactory<GoodHamburgerDbContext>
    {   
        public GoodHamburgerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GoodHamburgerDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=goodhamburger-sqldb-local;Persist Security Info=False;User ID=sa;Password=senha@123;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30");

            return new GoodHamburgerDbContext(optionsBuilder.Options);
        }
    }
}
