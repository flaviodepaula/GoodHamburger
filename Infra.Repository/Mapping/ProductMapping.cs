﻿using Infra.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Repository.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Entities.Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(prd => prd.ProductId);
            builder.Property(prd => prd.Value).HasColumnType("decimal");
            builder.Property(prd => prd.Description).HasMaxLength(255).HasColumnType("string");
            builder.Property(prd => prd.Category).HasMaxLength(30).HasColumnType("string");
        }
    }
}