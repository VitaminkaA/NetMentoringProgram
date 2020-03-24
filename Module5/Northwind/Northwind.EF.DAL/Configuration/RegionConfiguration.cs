using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.EF.DAL.Entities;

namespace Northwind.EF.DAL.Configuration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Region");
            builder.HasKey(e => e.Id)
                .IsClustered(false);
            builder.Property(e => e.Id)
                .HasColumnName("RegionID")
                .ValueGeneratedNever();
            builder.Property(e => e.RegionDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsFixedLength();

            builder.HasData(RegionsData);
        }

        private static Region[] RegionsData
            => new[]
            {
                new Region
                {
                    Id = 1,
                    RegionDescription = "Eastern"
                },
                new Region
                {
                    Id = 2,
                    RegionDescription = "Western"
                },
                new Region
                {
                    Id = 3,
                    RegionDescription = "Northern"
                },
                new Region
                {
                    Id = 4,
                    RegionDescription = "Southern"
                }
            };
    }
}
