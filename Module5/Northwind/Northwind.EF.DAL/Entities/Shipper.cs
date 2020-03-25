using System;
using System.Collections.Generic;

namespace Northwind.EF.DAL.Entities
{
    public class Shipper: BaseEntity<int>
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }

        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
