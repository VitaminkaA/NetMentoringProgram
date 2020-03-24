﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.EF.DAL.Entities;

namespace Northwind.EF.DAL.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
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
        }
    }
}
