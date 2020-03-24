using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.EF.DAL.Entities;

namespace Northwind.EF.DAL.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.City)
                .HasName("City");
            builder.HasIndex(e => e.CompanyName)
                .HasName("CompanyName");
            builder.HasIndex(e => e.PostalCode)
                .HasName("PostalCode");
            builder.HasIndex(e => e.Region)
                .HasName("Region");
            builder.Property(e => e.Id)
                .HasColumnName("CustomerID")
                .HasMaxLength(5)
                .IsFixedLength();
            builder.Property(e => e.Address).HasMaxLength(60);
            builder.Property(e => e.City).HasMaxLength(15);
            builder.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(e => e.ContactName).HasMaxLength(30);
            builder.Property(e => e.ContactTitle).HasMaxLength(30);
            builder.Property(e => e.Country).HasMaxLength(15);
            builder.Property(e => e.Fax).HasMaxLength(24);
            builder.Property(e => e.Phone).HasMaxLength(24);
            builder.Property(e => e.PostalCode).HasMaxLength(10);
            builder.Property(e => e.Region).HasMaxLength(15);

            builder.HasData(CustomersData);
        }

        private static Customer[] CustomersData
            => new[]
            {
                new Customer
                {
                    Id = "ALFKI",
                    CompanyName = "Alfreds Futterkiste",
                    ContactName = "Maria Anders",
                    ContactTitle = "Sales Representative",
                    Address = "Obere Str. 57",
                    City = "Berlin",
                    Region = null,
                    PostalCode = "12209",
                    Country = "Germany",
                    Phone = "030-0074321",
                    Fax = "030-0076545"
                },
                new Customer
                {
                    Id = "ANATR",
                    CompanyName = "Ana Trujillo Emparedados y helados",
                    ContactName = "Ana Trujillo",
                    ContactTitle = "Owner",
                    Address = "Avda. de la Constitucion 2222",
                    City = "Mexico D.F.",
                    Region = null,
                    PostalCode = "05021",
                    Country = "Mexico",
                    Phone = "(5) 555-4729",
                    Fax = "(5) 555-3745"
                },
                new Customer
                {
                    Id = "ANTON",
                    CompanyName = "Antonio Moreno Taqueria",
                    ContactName = "Antonio Moreno",
                    ContactTitle = "Owner",
                    Address = "Mataderos  2312",
                    City = "Mexico D.F.",
                    Region = null,
                    PostalCode = "05023",
                    Country = "Mexico",
                    Phone = "(5) 555-3932",
                    Fax = null
                },
                new Customer
                {
                    Id = "AROUT",
                    CompanyName = "Around the Horn",
                    ContactName = "Thomas Hardy",
                    ContactTitle = "Sales Representative",
                    Address = "120 Hanover Sq.",
                    City = "London",
                    Region = null,
                    PostalCode = "WA1 1DP",
                    Country = "UK",
                    Phone = "(171) 555-7788",
                    Fax = "(171) 555-6750"
                },
                new Customer
                {
                    Id = "BERGS",
                    CompanyName = "Berglunds snabbkop",
                    ContactName = "Christina Berglund",
                    ContactTitle = "Order Administrator",
                    Address = "Berguvsvagen  8",
                    City = "Lulea",
                    Region = null,
                    PostalCode = "S-958 22",
                    Country = "Sweden",
                    Phone = "0921-12 34 65",
                    Fax = "0921-12 34 67"
                }
            };
    }
}
