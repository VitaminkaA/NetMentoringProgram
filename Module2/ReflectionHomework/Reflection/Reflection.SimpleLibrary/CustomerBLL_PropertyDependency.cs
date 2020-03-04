using System;
using System.Collections.Generic;
using System.Text;
using Reflection.Container.Attributes;

namespace Reflection.SimpleLibrary
{
    public class CustomerBLL_PropertyDependency
    {
        [Import]
        public ICustomerDAL CustomerDAL { get; set; }
        [Import]
        public Logger Logger { get; set; }
    }
}
