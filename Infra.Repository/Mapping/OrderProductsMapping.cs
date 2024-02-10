using Infra.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Repository.Mapping
{
    internal class OrderProductsMapping : IEntityTypeConfiguration<Entities.OrdersProducts>
    {
        public void Configure(EntityTypeBuilder<OrdersProducts> builder)
        {
            builder.HasKey(x => new { x.OrderId, x.ProductId });

            builder
              .HasOne(x => x.Order)
              .WithMany(y => y.ProductsOnOrder)
              .HasForeignKey(x => x.OrderId);

            builder
                .HasOne(x => x.Product)
                .WithMany(y => y.OrdersProducts)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
