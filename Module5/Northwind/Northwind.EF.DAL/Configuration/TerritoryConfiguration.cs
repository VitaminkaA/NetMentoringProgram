using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.EF.DAL.Entities;

namespace Northwind.EF.DAL.Configuration
{
    public class TerritoryConfiguration : IEntityTypeConfiguration<Territory>
    {
        public void Configure(EntityTypeBuilder<Territory> builder)
        {
            builder.ToTable("Territories");
            builder.HasKey(e => e.Id)
                .IsClustered(false);
            builder.Property(e => e.Id)
                        .HasColumnName("TerritoryID")
                        .HasMaxLength(20);
            builder.Property(e => e.RegionId).HasColumnName("RegionID");
            builder.Property(e => e.TerritoryDescription)
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsFixedLength();
            builder.HasOne(d => d.Region)
                        .WithMany(p => p.Territories)
                        .HasForeignKey(d => d.RegionId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Territories_Region");

            builder.HasData(TerritoriesData);
        }

        private static Territory[] TerritoriesData
            => new[]
            {
                new Territory
                {
                    Id = "20852",
                    TerritoryDescription = "Rockville",
                    RegionId = 1
                },
                new Territory
                {
                    Id = "27403",
                    TerritoryDescription = "Greensboro",
                    RegionId =1
                },
                new Territory
                {
                    Id = "27511",
                    TerritoryDescription = "Cary",
                    RegionId =1
                },
                new Territory
                {
                    Id = "29202",
                    TerritoryDescription = "Columbia",
                    RegionId =4
                },
                new Territory
                {
                    Id = "30346",
                    TerritoryDescription = "Atlanta",
                    RegionId =4
                },
                new Territory
                {
                    Id = "31406",
                    TerritoryDescription = "Savannah",
                    RegionId =4
                },
                new Territory
                {
                    Id = "32859",
                    TerritoryDescription = "Orlando",
                    RegionId =4
                },
                new Territory
                {
                    Id = "33607",
                    TerritoryDescription = "Tampa",
                    RegionId =4
                },
                new Territory
                {
                    Id = "40222",
                    TerritoryDescription = "Louisville",
                    RegionId =1
                },
                new Territory
                {
                    Id = "44122",
                    TerritoryDescription = "Beachwood",
                    RegionId =3
                },
                new Territory
                {
                    Id = "45839",
                    TerritoryDescription = "Findlay",
                    RegionId =3
                },
                new Territory
                {
                    Id = "48075",
                    TerritoryDescription = "Southfield",
                    RegionId =3
                },
                new Territory
                {
                    Id = "48084",
                    TerritoryDescription = "Troy",
                    RegionId =3
                },
                new Territory
                {
                    Id = "48304",
                    TerritoryDescription = "Bloomfield Hills",
                    RegionId =3
                },
                new Territory
                {
                    Id = "53404",
                    TerritoryDescription = "Racine",
                    RegionId =3
                },
                new Territory
                {
                    Id = "55113",
                    TerritoryDescription = "Roseville",
                    RegionId =3
                },
                new Territory
                {
                    Id = "55439",
                    TerritoryDescription = "Minneapolis",
                    RegionId =3
                }
            };
    }
}
