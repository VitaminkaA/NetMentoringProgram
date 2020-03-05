using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Reflection.Container.Attributes;

namespace Reflection.Container.Services
{
    public class InstanceWithProperties : Instance
    {
        public readonly IEnumerable<PropertyInfo> PropertiesType;

        public InstanceWithProperties(Type type) : base(type)
        {
            PropertiesType = type.GetProperties()
                .Where(x => x.GetCustomAttribute<ImportAttribute>() != null);
        }
    }
}
