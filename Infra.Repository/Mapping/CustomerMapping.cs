using Infra.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Repository.Mapping
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {          
            builder.HasKey(prd => prd.CustomerId);
            builder.Property(prd => prd.Name).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(prd => prd.Email).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(prd => prd.PhoneNumber).HasMaxLength(14).HasColumnType("varchar");
            builder.Property(x => x.Active).HasColumnName("Active").IsRequired(true).HasDefaultValue(false);
            
            //complex type in EF8.
            builder.ComplexProperty(a => a.Address, a => a.IsRequired());
        }
    }
}
