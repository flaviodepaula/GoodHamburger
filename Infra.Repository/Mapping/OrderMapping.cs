using Infra.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Repository.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<Entities.Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(order => order.OrderId);
            builder.Property(order => order.TotalAmount).HasColumnType("decimal").HasPrecision(10,2);                   
        }
    }
}
