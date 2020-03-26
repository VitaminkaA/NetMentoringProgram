using System;
using System.Collections.Generic;

namespace Northwind.EF.DAL.Entities
{
    public class Region: BaseEntity<int>
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        public string RegionDescription { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }
    }
}
