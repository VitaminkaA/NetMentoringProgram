using System;
using System.Collections.Generic;
using System.Text;
using Reflection.Container.Attributes;
using Reflection.SampleLibrary;

namespace Reflection.SampleLibrary
{
    [ImportConstructor]
    [Export(typeof(ICustomerDALWithDependency))]
    public class CustomDALWithDependency : ICustomerDALWithDependency
    {
        public Logger Logger { get; }

        public CustomDALWithDependency(Logger logger)
            => Logger = logger;

        public string GetCustomerName() => "CustomDALWithDependency";
    }
}

