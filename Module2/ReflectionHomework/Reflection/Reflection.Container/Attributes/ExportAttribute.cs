using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection.Container.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportAttribute : Attribute
    {
        public Type Type { get; }
        public ExportAttribute() { }

        public ExportAttribute(Type type) 
            => Type = type ?? throw new ArgumentNullException();
    }
}
