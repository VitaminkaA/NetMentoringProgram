using System;

namespace Reflection.Container.Services
{
    public class InstanceEntity
    {
        public Type Type { get; }

        public InstanceEntity(Type type) 
            => Type = type ?? throw new ArgumentNullException();
    }
}
