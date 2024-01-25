using Infra.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Repository.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Entities.Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(prd => prd.ProductId);
            builder.Property(prd => prd.Value).HasColumnType("decimal").HasPrecision(10, 2);
            builder.Property(prd => prd.Description).HasMaxLength(255).HasColumnType("varchar");
            builder.Property(prd => prd.Category).HasMaxLength(30).HasColumnType("varchar");
            builder.Property(prd => prd.CategoryType).HasMaxLength(30).HasColumnType("varchar");
        }
    }
}
