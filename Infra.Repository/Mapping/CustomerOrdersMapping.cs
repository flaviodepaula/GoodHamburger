using Infra.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Repository.Mapping
{
    public class CustomerOrdersMapping : IEntityTypeConfiguration<CustomerOrders>
    {
        public void Configure(EntityTypeBuilder<CustomerOrders> builder)
        {
            builder.HasKey(x => new { x.CustomerId, x.OrderId });
            builder
              .HasOne(x => x.Customer)
              .WithMany(y => y.Orders)
              .HasForeignKey(x => x.OrderId);
        }
    }
}

