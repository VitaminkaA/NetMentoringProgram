using LinqToDB.Mapping;

namespace Northwind.EF.DAL.Entities
{
    [Table("Products")]
    public class Product
    {
        [Column, Identity, PrimaryKey]
        public int ProductId { get; set; }
        [Column]
        public string ProductName { get; set; }
        [Column]
        public int? SupplierId { get; set; }
        [Column]
        public int? CategoryId { get; set; }
        [Column]
        public string QuantityPerUnit { get; set; }
        [Column]
        public decimal? UnitPrice { get; set; }
        [Column]
        public short? UnitsInStock { get; set; }
        [Column]
        public short? UnitsOnOrder { get; set; }
        [Column]
        public short? ReorderLevel { get; set; }
        [Column]
        public bool Discontinued { get; set; }

        [Association(ThisKey = nameof(CategoryId), 
            OtherKey = nameof(Entities.Category.Id), 
            CanBeNull = true)]
        public Category Category { get; set; }

        [Association(ThisKey = nameof(SupplierId),
            OtherKey = nameof(Entities.Supplier.SupplierId),
            CanBeNull = true)]
        public Supplier Supplier { get; set; }
    }
}
