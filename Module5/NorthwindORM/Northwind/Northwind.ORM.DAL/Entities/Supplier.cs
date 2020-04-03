using System.Collections.Generic;
using LinqToDB.Mapping;

namespace Northwind.EF.DAL.Entities
{
    [Table("Suppliers")]
    public class Supplier
    {
        [Column]
        [Identity]
        [PrimaryKey]
        public int SupplierId { get; set; }
        [Column]
        public string CompanyName { get; set; }
        [Column]
        public string ContactName { get; set; }
        [Column]
        public string ContactTitle { get; set; }
        [Column]
        public string Address { get; set; }
        [Column]
        public string City { get; set; }
        [Column]
        public string Region { get; set; }
        [Column]
        public string PostalCode { get; set; }
        [Column]
        public string Country { get; set; }
        [Column]
        public string Phone { get; set; }
        [Column]
        public string Fax { get; set; }
        [Column]
        public string HomePage { get; set; }
    }
}
