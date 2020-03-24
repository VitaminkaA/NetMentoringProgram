using System;
using System.Collections.Generic;

namespace Northwind.EF.DAL.Entities
{
    public class Category: BaseEntity<int>
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
