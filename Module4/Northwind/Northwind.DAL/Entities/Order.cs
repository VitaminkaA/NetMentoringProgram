using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Entities
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public OrderStatus Status 
        {
            get
            {
                if (OrderDate == null)
                    return OrderStatus.New;
                return ShippedDate == null 
                    ? OrderStatus.InWork 
                    : OrderStatus.Completed;
            }
        }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? EmployeeID { get; set; }
        public string CustomerID { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
