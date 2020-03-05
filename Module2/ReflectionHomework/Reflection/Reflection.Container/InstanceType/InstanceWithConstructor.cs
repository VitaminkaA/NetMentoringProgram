﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Reflection.Container.Services
{
    internal class InstanceWithConstructor : Instance
    {
        public readonly IEnumerable<ParameterInfo> ConstructorParameterType;

        public InstanceWithConstructor(Type type) : base(type)
        {
            var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance);

            if (constructors.Length != 1)
                throw new Exception();

            ConstructorParameterType = constructors.First().GetParameters();
        }
    }
}
