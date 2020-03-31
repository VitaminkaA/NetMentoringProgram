using System;
using System.Collections.Generic;
using LinqToDB.Mapping;

namespace Northwind.EF.DAL.Entities
{
    [Table("Shippers")]
    public class Shipper
    {
        [Column, PrimaryKey, Identity]
        public int ShipperId { get; set; }
        [Column]
        public string CompanyName { get; set; }
        [Column]
        public string Phone { get; set; }

        [Association(
            ThisKey = nameof(ShipperId),
            OtherKey = nameof(Order.ShipVia),
            CanBeNull = true)]
        public IEnumerable<Order> Orders { get; set; }
    }
}
