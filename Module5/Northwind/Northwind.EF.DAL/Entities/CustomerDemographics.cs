using System;
using System.Collections.Generic;

namespace Northwind.EF.DAL.Entities
{
    public class CustomerDemographics: BaseEntity<int>
    {
        public CustomerDemographics()
        {
            CustomerCustomerDemo = new HashSet<CustomerCustomerDemo>();
        }

        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }

        public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
    }
}
