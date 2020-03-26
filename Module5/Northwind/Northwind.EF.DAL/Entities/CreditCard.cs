using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.EF.DAL.Entities
{
    public class CreditCard : BaseEntity<int>
    {
        public DateTime CardExpirationDate { get; set; }
        public string CardHolderName { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
