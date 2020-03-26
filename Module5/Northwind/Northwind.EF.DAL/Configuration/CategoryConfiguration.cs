using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.EF.DAL.Entities;

namespace Northwind.EF.DAL.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.CategoryName)
                .HasName("CategoryName");
            builder.Property(e => e.Id).HasColumnName("CategoryID");
            builder.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15);
            builder.Property(e => e.Description).HasColumnType("ntext");

            builder.HasData(CategoriesData);
        }

        private static Category[] CategoriesData
            => new[]
            {
                new Category
                {
                    Id = 1,
                    CategoryName = "Beverages",
                    Description = "Soft drinks, coffees, teas, beers, and ales"
                },
                new Category
                {
                    Id=2,
                    CategoryName = "Condiments",
                    Description = "Sweet and savory sauces, relishes, spreads, and seasonings"
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Confections",
                    Description = "Desserts, candies, and sweet breads"
                }
            };
    }
}
