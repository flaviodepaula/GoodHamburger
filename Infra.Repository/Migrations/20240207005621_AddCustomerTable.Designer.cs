﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Repository.Migrations
{
    [DbContext(typeof(GoodHamburgerDbContext))]
    [Migration("20240207005621_AddCustomerTable")]
    partial class AddCustomerTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infra.Repository.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "Infra.Repository.Entities.Customer.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Number")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");
                        });

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Infra.Repository.Entities.Orders", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalAmount")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Infra.Repository.Entities.OrdersProducts", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrdersProducts");
                });

            modelBuilder.Entity("Infra.Repository.Entities.Products", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<string>("CategoryType")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<decimal>("Value")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Infra.Repository.Entities.OrdersProducts", b =>
                {
                    b.HasOne("Infra.Repository.Entities.Orders", "Order")
                        .WithMany("ProductsOnOrder")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infra.Repository.Entities.Products", "Product")
                        .WithMany("OrdersProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Infra.Repository.Entities.Orders", b =>
                {
                    b.Navigation("ProductsOnOrder");
                });

            modelBuilder.Entity("Infra.Repository.Entities.Products", b =>
                {
                    b.Navigation("OrdersProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
