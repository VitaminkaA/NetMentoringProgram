using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.EF.DAL.Entities;

namespace Northwind.EF.DAL.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.CategoryId)
                .HasName("CategoryID");
            builder.HasIndex(e => e.ProductName)
                .HasName("ProductName");
            builder.HasIndex(e => e.SupplierId)
                .HasName("SuppliersProducts");
            builder.Property(e => e.Id).HasColumnName("ProductID");
            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");
            builder.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            builder.Property(e => e.ReorderLevel).HasDefaultValueSql("((0))");
            builder.Property(e => e.SupplierId).HasColumnName("SupplierID");
            builder.Property(e => e.UnitPrice)
                .HasColumnType("money")
                .HasDefaultValueSql("((0))");
            builder.Property(e => e.UnitsInStock).HasDefaultValueSql("((0))");
            builder.Property(e => e.UnitsOnOrder).HasDefaultValueSql("((0))");
            builder.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_Categories");
            builder.HasOne(d => d.Supplier)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Products_Suppliers");

            builder.HasData(ProductsData);
        }

        private static Product[] ProductsData
            => new[]
            {
                new Product
                {
                    Id = 1,
                    ProductName = "Chai",
                    SupplierId = 1,
                    CategoryId = 1,
                    QuantityPerUnit = "10 boxes x 20 bags",
                    UnitPrice = 18m,
                    UnitsInStock = 39,
                    UnitsOnOrder = 0,
                    ReorderLevel = 10,
                    Discontinued = false
                },
                new Product
                {
                    Id = 2,
                    ProductName = "Chang",
                    SupplierId = 1,
                    CategoryId = 1,
                    QuantityPerUnit = "24 - 12 oz bottles",
                    UnitPrice = 19m,
                    UnitsInStock = 17,
                    UnitsOnOrder = 40,
                    ReorderLevel = 25,
                    Discontinued = false
                },
                new Product
                {
                    Id = 3,
                    ProductName = "Aniseed Syrup",
                    SupplierId = 1,
                    CategoryId = 2,
                    QuantityPerUnit = "",
                    UnitPrice = 10m,
                    UnitsInStock = 13,
                    UnitsOnOrder = 70,
                    ReorderLevel = 25,
                    Discontinued = false
                },
                new Product
                {
                    Id = 4,
                    ProductName = "Chef Anton's Cajun Seasoning",
                    SupplierId = 2,
                    CategoryId = 2,
                    QuantityPerUnit = "48 - 6 oz jars",
                    UnitPrice = 22m,
                    UnitsInStock = 53,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    Discontinued = false
                },
                new Product
                {
                    Id = 5,
                    ProductName = "Chef Anton's Gumbo Mix",
                    SupplierId = 2,
                    CategoryId = 2,
                    QuantityPerUnit = "36 boxes",
                    UnitPrice = 21.35m,
                    UnitsInStock = 0,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    Discontinued = true
                },
                new Product
                {
                    Id = 6,
                    ProductName = "Northwoods Cranberry Sauce",
                    SupplierId = 3,
                    CategoryId = 2,
                    QuantityPerUnit = "12 - 12 oz jars",
                    UnitPrice = 40m,
                    UnitsInStock = 6,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    Discontinued = false
                },
                new Product
                {
                    Id = 7,
                    ProductName = "Louisiana Fiery Hot Pepper Sauce",
                    SupplierId = 2,
                    CategoryId = 2,
                    QuantityPerUnit = "32 - 8 oz bottles",
                    UnitPrice = 21.05m,
                    UnitsInStock = 76,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    Discontinued = false
                },
                new Product
                {
                    Id = 8,
                    ProductName = "Louisiana Hot Spiced Okra",
                    SupplierId = 2,
                    CategoryId = 2,
                    QuantityPerUnit = "24 - 8 oz jars",
                    UnitPrice = 17m,
                    UnitsInStock = 4,
                    UnitsOnOrder = 100,
                    ReorderLevel = 20,
                    Discontinued = false
                }
            };
    }
}
