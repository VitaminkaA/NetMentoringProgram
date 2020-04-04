using System;
using System.Collections.Generic;
using LinqToDB.Mapping;

namespace Northwind.EF.DAL.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Column("CategoryId"), PrimaryKey, Identity]
        public int Id { get; set; }

        [Column("CategoryName")]
        public string Name { get; set; }
        [Column]
        public string Description { get; set; }
    }
}
