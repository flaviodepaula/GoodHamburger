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

            //builder.OwnsOne(x => x.Address).Property(x => x.PostalCode).HasColumnName("PostalCode").HasMaxLength(12).IsRequired(true);
            //builder.OwnsOne(x => x.Address).Property(x => x.Street).HasColumnName("Street").HasMaxLength(50).IsRequired(true);
            //builder.OwnsOne(x => x.Address).Property(x => x.ReferenceDetails).HasColumnName("ReferenceDetails").HasMaxLength(100).IsRequired(true);
            //builder.OwnsOne(x => x.Address).Property(x => x.Number).HasColumnName("Number").HasMaxLength(10).IsRequired(true);
            //builder.OwnsOne(x => x.Address).Property(x => x.City).HasColumnName("City").HasMaxLength(30).IsRequired(true);
            //builder.OwnsOne(x => x.Address).Property(x => x.Neighborhood).HasColumnName("Neighborhood").HasMaxLength(40).IsRequired(true);
        }
    }
}
