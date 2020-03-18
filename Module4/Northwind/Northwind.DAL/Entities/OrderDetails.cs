using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Entities
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public Product Product { get; set; }
    }
}
