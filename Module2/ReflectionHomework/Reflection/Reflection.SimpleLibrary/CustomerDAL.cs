using System;
using System.Collections.Generic;
using System.Text;
using Reflection.Container.Attributes;

namespace Reflection.SimpleLibrary
{
    [Export(typeof(ICustomerDAL))]
    public class CustomerDAL : ICustomerDAL
    {
        public string GetCustomerName()
        {
            return "Customer";
        }
    }
}
