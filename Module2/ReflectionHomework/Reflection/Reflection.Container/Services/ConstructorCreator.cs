using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection.Container.Services
{
    public class ConstructorCreator : ICreator
    {

        public ConstructorCreator(Type type)
        {

        }

        public object CreateInstance(Type type)
        {
            var constructors = type.GetConstructors();
            return null;
        }
    }
}
