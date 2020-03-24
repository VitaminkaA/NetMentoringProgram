using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.EF.DAL.Entities;

namespace Northwind.EF.DAL.Configuration
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.ToTable("Order Details");
            builder.HasKey(e => new { e.OrderId, e.ProductId })
                .HasName("PK_Order_Details");
            builder.ToTable("Order Details");
            builder.HasIndex(e => e.OrderId)
                .HasName("OrdersOrder_Details");
            builder.HasIndex(e => e.ProductId)
                .HasName("ProductsOrder_Details");
            builder.Property(e => e.OrderId).HasColumnName("OrderID");
            builder.Property(e => e.ProductId).HasColumnName("ProductID");
            builder.Property(e => e.Quantity).HasDefaultValueSql("((1))");
            builder.Property(e => e.UnitPrice).HasColumnType("money");
            builder.HasOne(d => d.Order)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Orders");
            builder.HasOne(d => d.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Products");
            
           builder.HasData(OrdersDetailsData);
        }

        private static OrderDetails[] OrdersDetailsData
            => new[]
            {
                new OrderDetails
                {
                    OrderId = 10835,
                    ProductId = 1,
                    UnitPrice = 55m,
                    Quantity = 15,
                    Discount = 0,
                },
                new OrderDetails
                {
                    OrderId = 10835,
                    ProductId = 2,
                    UnitPrice = 13m,
                    Quantity = 2,
                    Discount = 0,
                },
                new OrderDetails
                {
                    OrderId = 10952,
                    ProductId = 6,
                    UnitPrice = 25m,
                    Quantity = 16,
                    Discount = 0,
                },
                new OrderDetails
                {
                    OrderId = 10952,
                    ProductId = 7,
                    UnitPrice = 45.60m,
                    Quantity = 2,
                    Discount = 0,
                },
                new OrderDetails
                {
                    OrderId = 11011,
                    ProductId = 8,
                    UnitPrice = 11.25m,
                    Quantity = 40,
                    Discount = 0.05f,
                },
                new OrderDetails
                {
                    OrderId = 11011,
                    ProductId = 3,
                    UnitPrice = 21.50m,
                    Quantity = 20,
                    Discount = 0,
                },
                new OrderDetails
                {
                    OrderId = 10625,
                    ProductId = 1,
                    UnitPrice = 23.25m,
                    Quantity = 3,
                    Discount = 0,
                },
                new OrderDetails
                {
                    OrderId = 10625,
                    ProductId = 2,
                    UnitPrice = 14m,
                    Quantity = 5,
                    Discount = 0,
                },
                new OrderDetails
                {
                    OrderId = 10625,
                    ProductId = 5,
                    UnitPrice = 4m,
                    Quantity = 10,
                    Discount = 0,
                },
                new OrderDetails
                {
                    OrderId = 10759,
                    ProductId = 2,
                    UnitPrice = 32m,
                    Quantity = 10,
                    Discount = 0,
                },
                new OrderDetails
                {
                    OrderId = 10365,
                    ProductId = 7,
                    UnitPrice = 16.80m,
                    Quantity = 24,
                    Discount = 0,
                },
                new OrderDetails
                {
                    OrderId = 10677,
                    ProductId = 6,
                    UnitPrice = 31.23m,
                    Quantity = 30,
                    Discount = 0.15f,
                },
                new OrderDetails
                {
                    OrderId = 10677,
                    ProductId = 8,
                    UnitPrice = 2.50m,
                    Quantity = 8,
                    Discount = 0.15f,
                },
                new OrderDetails
                {
                    OrderId = 10682,
                    ProductId = 3,
                    UnitPrice = 2.50m,
                    Quantity = 40,
                    Discount = 0,
                },
                new OrderDetails
                {
                    OrderId = 10856,
                    ProductId = 2,
                    UnitPrice = 19m,
                    Quantity = 20,
                    Discount = 0,
                },
                new OrderDetails
                {
                    OrderId = 10856,
                    ProductId = 4,
                    UnitPrice = 14m,
                    Quantity = 20,
                    Discount = 0,
                }
            };
    }
}
