using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.EF.DAL.Entities;

namespace Northwind.EF.DAL.Configuration
{
    public class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.ToTable("Shippers");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ShipperID");
            builder.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(e => e.Phone).HasMaxLength(24);

            builder.HasData(ShippersData);
        }

        private static Shipper[] ShippersData
            => new[]
            {
                new Shipper
                {
                    Id = 1,
                    CompanyName = "Speedy Express",
                    Phone = "(503) 555-9831"
                },
                new Shipper
                {
                    Id = 2,
                    CompanyName = "United Package",
                    Phone = "(503) 555-3199"
                },
                new Shipper
                {
                    Id = 3,
                    CompanyName = "Federal Shipping",
                    Phone = "(503) 555-9931"
                }
            };
    }
}
