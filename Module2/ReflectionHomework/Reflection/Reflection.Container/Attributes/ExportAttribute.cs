using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection.Container.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportAttribute : Attribute
    {
        public ExportAttribute() { }

        public ExportAttribute(Type type)
        {

        }
    }
}
