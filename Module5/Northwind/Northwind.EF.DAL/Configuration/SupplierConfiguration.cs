using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.EF.DAL.Entities;

namespace Northwind.EF.DAL.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.CompanyName)
                .HasName("CompanyName");
            builder.HasIndex(e => e.PostalCode)
                .HasName("PostalCode");
            builder.Property(e => e.Id).HasColumnName("SupplierID");
            builder.Property(e => e.Address).HasMaxLength(60);
            builder.Property(e => e.City).HasMaxLength(15);
            builder.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(e => e.ContactName).HasMaxLength(30);
            builder.Property(e => e.ContactTitle).HasMaxLength(30);
            builder.Property(e => e.Country).HasMaxLength(15);
            builder.Property(e => e.Fax).HasMaxLength(24);
            builder.Property(e => e.HomePage).HasColumnType("ntext");
            builder.Property(e => e.Phone).HasMaxLength(24);
            builder.Property(e => e.PostalCode).HasMaxLength(10);
            builder.Property(e => e.Region).HasMaxLength(15);

            builder.HasData(SuppliersData);
        }

        private static Supplier[] SuppliersData
            => new[]
            {
                new Supplier
                {
                    Id = 1,
                    CompanyName = "Exotic Liquids",
                    ContactName = "Charlotte Cooper",
                    ContactTitle = "Purchasing Manager",
                    Address = "49 Gilbert St.",
                    City = "London",
                    Region = null,
                    PostalCode = "EC1 4SD",
                    Country = "UK",
                    Phone = "(171) 555-2222",
                    Fax = null,
                    HomePage = null
                },
                new Supplier
                {
                    Id = 2,
                    CompanyName = "New Orleans Cajun Delights",
                    ContactName = "Shelley Burke",
                    ContactTitle = "Order Administrator",
                    Address = "P.O. Box 78934",
                    City = "New Orleans",
                    Region = "LA",
                    PostalCode = "70117",
                    Country = "USA",
                    Phone = "(100) 555-4822",
                    Fax = null,
                    HomePage = "#CAJUN.HTM#"
                },
                new Supplier
                {
                    Id = 3,
                    CompanyName = "Grandma Kelly's Homestead",
                    ContactName = "Regina Murphy",
                    ContactTitle = "Sales Representative",
                    Address = "707 Oxford Rd.",
                    City = "Ann Arbor",
                    Region = "MI",
                    PostalCode = "48104",
                    Country = "USA",
                    Phone = "(313) 555-5735",
                    Fax = "(313) 555-3349",
                    HomePage = null
                },
                new Supplier
                {
                    Id = 4,
                    CompanyName = "Tokyo Traders",
                    ContactName = "Yoshi Nagase",
                    ContactTitle = "Marketing Manager",
                    Address = "9-8 Sekimai Musashino-shi",
                    City = "Tokyo",
                    Region = null,
                    PostalCode = "100",
                    Country = "Japan",
                    Phone = "(03) 3555-5011",
                    Fax = null,
                    HomePage = null
                },
                new Supplier
                {
                    Id = 5,
                    CompanyName = "Cooperativa de Quesos 'Las Cabras'",
                    ContactName = "Antonio del Valle Saavedra",
                    ContactTitle = "Export Administrator",
                    Address = "Calle del Rosal 4",
                    City = "Oviedo",
                    Region = "Asturias",
                    PostalCode = "33007",
                    Country = "Spain",
                    Phone = "(98) 598 76 54",
                    Fax = null,
                    HomePage = null
                }
            };
    }
}
