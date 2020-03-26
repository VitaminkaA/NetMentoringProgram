using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.EF.DAL.Entities;

namespace Northwind.EF.DAL.Configuration
{
    public class EmployeeTerritoryConfiguration : IEntityTypeConfiguration<EmployeeTerritory>
    {
        public void Configure(EntityTypeBuilder<EmployeeTerritory> builder)
        {
            builder.ToTable("EmployeeTerritories");
            builder.HasKey(e => new { e.EmployeeId, e.TerritoryId })
                .IsClustered(false);
            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            builder.Property(e => e.TerritoryId)
                .HasColumnName("TerritoryID")
                .HasMaxLength(20);
            builder.HasOne(d => d.Employee)
                .WithMany(p => p.EmployeeTerritories)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeTerritories_Employees");
            builder.HasOne(d => d.Territory)
                .WithMany(p => p.EmployeeTerritories)
                .HasForeignKey(d => d.TerritoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeTerritories_Territories");

            builder.HasData(EmployeeTerritoriesData);
        }

        private static EmployeeTerritory[] EmployeeTerritoriesData
            => new[]
            {
                new EmployeeTerritory
                {
                    EmployeeId = 1,
                    TerritoryId = "20852"
                },
                new EmployeeTerritory
                {
                    EmployeeId = 1,
                    TerritoryId = "27403"
                },
                new EmployeeTerritory
                {
                    EmployeeId = 2,
                    TerritoryId = "27511"
                },
                new EmployeeTerritory
                {
                    EmployeeId = 2,
                    TerritoryId = "29202"
                },
                new EmployeeTerritory
                {
                    EmployeeId = 2,
                    TerritoryId = "30346"
                },
                new EmployeeTerritory
                {
                    EmployeeId = 2,
                    TerritoryId = "31406"
                },
                new EmployeeTerritory
                {
                    EmployeeId = 2,
                    TerritoryId = "32859"
                },
                new EmployeeTerritory
                {
                    EmployeeId = 2,
                    TerritoryId = "33607"
                },
                new EmployeeTerritory
                {
                    EmployeeId = 2,
                    TerritoryId = "40222"
                },
                new EmployeeTerritory
                {
                    EmployeeId = 3,
                    TerritoryId = "45839"
                },
                new EmployeeTerritory
                {
                    EmployeeId = 3,
                    TerritoryId = "48075"
                },
                new EmployeeTerritory
                {
                    EmployeeId = 3,
                    TerritoryId = "48084"
                },
                new EmployeeTerritory
                {
                    EmployeeId = 3,
                    TerritoryId = "48304"
                },
                new EmployeeTerritory
                {
                    EmployeeId = 3,
                    TerritoryId = "53404"
                },
                new EmployeeTerritory
                {
                    EmployeeId = 3,
                    TerritoryId = "55113"
                },
                new EmployeeTerritory
                {
                    EmployeeId = 3,
                    TerritoryId = "55439"
                }
            };
    }
}
