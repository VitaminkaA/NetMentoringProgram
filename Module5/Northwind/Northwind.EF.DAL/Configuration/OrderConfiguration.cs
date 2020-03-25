using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.EF.DAL.Entities;

namespace Northwind.EF.DAL.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.CustomerId)
                .HasName("CustomersOrders");
            builder.HasIndex(e => e.EmployeeId)
                .HasName("EmployeesOrders");
            builder.HasIndex(e => e.OrderDate)
                .HasName("OrderDate");
            builder.HasIndex(e => e.ShipPostalCode)
                .HasName("ShipPostalCode");
            builder.HasIndex(e => e.ShipVia)
                .HasName("ShippersOrders");
            builder.HasIndex(e => e.ShippedDate)
                .HasName("ShippedDate");
            builder.Property(e => e.Id).HasColumnName("OrderID");
            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerID")
                .HasMaxLength(5)
                .IsFixedLength();
            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            builder.Property(e => e.Freight)
                .HasColumnType("money")
                .HasDefaultValueSql("((0))");
            builder.Property(e => e.OrderDate).HasColumnType("datetime");
            builder.Property(e => e.RequiredDate).HasColumnType("datetime");
            builder.Property(e => e.ShipAddress).HasMaxLength(60);
            builder.Property(e => e.ShipCity).HasMaxLength(15);
            builder.Property(e => e.ShipCountry).HasMaxLength(15);
            builder.Property(e => e.ShipName).HasMaxLength(40);
            builder.Property(e => e.ShipPostalCode).HasMaxLength(10);
            builder.Property(e => e.ShipRegion).HasMaxLength(15);
            builder.Property(e => e.ShippedDate).HasColumnType("datetime");
            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Orders_Customers");
            builder.HasOne(d => d.Employee)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Orders_Employees");
            builder.HasOne(d => d.ShipViaNavigation)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipVia)
                .HasConstraintName("FK_Orders_Shippers");

            builder.HasData(OrdersData);
        }

        private static Order[] OrdersData
            => new[]
            {
                new Order
                {
                    Id = 10835,
                    CustomerId = "ALFKI",
                    EmployeeId = 1,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 3,
                    Freight=69.53m,
                    ShipName = "Alfred's Futterkiste",
                    ShipAddress = "Obere Str. 57",
                    ShipCity = "Berlin",
                    ShipRegion = null,
                    ShipPostalCode = "12209",
                    ShipCountry = "Germany"
                },
                new Order
                {
                    Id = 10952,
                    CustomerId = "ALFKI",
                    EmployeeId = 1,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 1,
                    Freight=40.42m,
                    ShipName = "Alfred's Futterkiste",
                    ShipAddress = "Obere Str. 57",
                    ShipCity = "Berlin",
                    ShipRegion = null,
                    ShipPostalCode = "12209",
                    ShipCountry = "Germany"
                },
                new Order
                {
                    Id = 11011,
                    CustomerId = "ALFKI",
                    EmployeeId = 3,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 1,
                    Freight=1.21m,
                    ShipName = "Alfred's Futterkiste",
                    ShipAddress = "Obere Str. 57",
                    ShipCity = "Berlin",
                    ShipRegion = null,
                    ShipPostalCode = "12209",
                    ShipCountry = "Germany"
                },
                new Order
                {
                    Id = 10625,
                    CustomerId = "ANATR",
                    EmployeeId = 3,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 1,
                    Freight=43.90m,
                    ShipName = "Ana Trujillo Emparedados y helados",
                    ShipAddress = "Avda. de la Constitución 2222",
                    ShipCity = "México D.F.",
                    ShipRegion = null,
                    ShipPostalCode = "05021",
                    ShipCountry = "Mexico"
                },
                new Order
                {
                    Id = 10759,
                    CustomerId = "ANATR",
                    EmployeeId = 3,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 3,
                    Freight=11.99m,
                    ShipName = "Ana Trujillo Emparedados y helados",
                    ShipAddress = "Avda. de la Constitución 2222",
                    ShipCity = "México D.F.",
                    ShipRegion = null,
                    ShipPostalCode = "05021",
                    ShipCountry = "Mexico"
                },
                new Order
                {
                    Id = 10365,
                    CustomerId = "ANTON",
                    EmployeeId = 3,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 2,
                    Freight=22.00m,
                    ShipName = "Antonio Moreno Taquería",
                    ShipAddress = "Mataderos  2312",
                    ShipCity = "México D.F.",
                    ShipRegion = null,
                    ShipPostalCode = "05023",
                    ShipCountry = "Mexico"
                },
                new Order
                {
                    Id = 10677,
                    CustomerId = "ANTON",
                    EmployeeId = 1,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 3,
                    Freight=4.03m,
                    ShipName = "Antonio Moreno Taquería",
                    ShipAddress = "Mataderos  2312",
                    ShipCity = "México D.F.",
                    ShipRegion = null,
                    ShipPostalCode = "05023",
                    ShipCountry = "Mexico"
                },
                new Order
                {
                    Id = 10682,
                    CustomerId = "ANTON",
                    EmployeeId = 3,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 2,
                    Freight=36.13m,
                    ShipName = "Antonio Moreno Taquería",
                    ShipAddress = "Mataderos  2312",
                    ShipCity = "México D.F.",
                    ShipRegion = null,
                    ShipPostalCode = "05023",
                    ShipCountry = "Mexico"
                },
                new Order
                {
                    Id = 10856,
                    CustomerId = "ANTON",
                    EmployeeId = 3,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 2,
                    Freight=58.43m,
                    ShipName = "Antonio Moreno Taquería",
                    ShipAddress = "Mataderos  2312",
                    ShipCity = "México D.F.",
                    ShipRegion = null,
                    ShipPostalCode = "05023",
                    ShipCountry = "Mexico"
                }
            };
    }
}
