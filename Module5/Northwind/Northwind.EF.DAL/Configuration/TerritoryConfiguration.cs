using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.EF.DAL.Entities;

namespace Northwind.EF.DAL.Configuration
{
    public class TerritoryConfiguration : IEntityTypeConfiguration<Territory>
    {
        public void Configure(EntityTypeBuilder<Territory> builder)
        {
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
        }
    }
}
