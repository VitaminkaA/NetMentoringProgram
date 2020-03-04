using Reflection.Container.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection.SimpleLibrary
{
    [ImportConstructor]
    public class CustomerBLL_ConstructorDependency
    {
        public CustomerBLL_ConstructorDependency(ICustomerDAL dal, Logger logger) { }
    }
}
