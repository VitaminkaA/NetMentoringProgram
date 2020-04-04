using System;
using System.Collections.Generic;
using LinqToDB.Mapping;

namespace Northwind.EF.DAL.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Column, PrimaryKey, Identity]
        public int OrderId { get; set; }
        [Column]
        public string CustomerId { get; set; }
        [Column]
        public int? EmployeeId { get; set; }
        [Column]
        public DateTime? OrderDate { get; set; }
        [Column]
        public DateTime? RequiredDate { get; set; }
        [Column]
        public DateTime? ShippedDate { get; set; }
        [Column]
        public int? ShipVia { get; set; }
        [Column]
        public decimal? Freight { get; set; }
        [Column]
        public string ShipName { get; set; }
        [Column]
        public string ShipAddress { get; set; }
        [Column]
        public string ShipCity { get; set; }
        [Column]
        public string ShipRegion { get; set; }
        [Column]
        public string ShipPostalCode { get; set; }
        [Column]
        public string ShipCountry { get; set; }

        public Employee Employee { get; set; }

        [Association(
            ThisKey = nameof(ShipVia),
            OtherKey = nameof(Shipper.ShipperId),
            CanBeNull = true)]
        public Shipper ShipViaNavigation { get; set; }
    }
}
