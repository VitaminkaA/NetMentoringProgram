using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Entities
{
    public class CustOrdersDetail
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public decimal ExtendedPrice { get; set; }
    }
}
