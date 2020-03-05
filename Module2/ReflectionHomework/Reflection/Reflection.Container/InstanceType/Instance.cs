using System;

namespace Reflection.Container.Services
{
    public class Instance
    {
        public Type Type { get; }

        public Instance(Type type) 
            => Type = type ?? throw new ArgumentNullException();
    }
}
