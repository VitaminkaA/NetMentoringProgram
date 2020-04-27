using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Reflection.Container.Attributes;
using Reflection.Container.Services;

namespace Reflection.Container
{
    public class Container
    {
        private readonly Dictionary<Type, InstanceEntity> _container = new Dictionary<Type, InstanceEntity>();

        public void AddAssembly(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException();

            foreach (var type in assembly.DefinedTypes)
                AddType(type);
        }

        public void AddType(Type type)
            => AddType(type, type);

        public void AddType(Type instanceType, Type type)
        {
            if (instanceType == null || type == null)
                throw new ArgumentNullException();

            var exportAttribute = instanceType.GetCustomAttribute<ExportAttribute>();
            var constructorAttribute = instanceType.GetCustomAttribute<ImportConstructorAttribute>() != null;
            var importAttribute = instanceType.GetProperties()
                .Any(x => x.GetCustomAttribute<ImportAttribute>() != null);

            if (exportAttribute != null)
                type = exportAttribute.Type ?? type;

            if (exportAttribute == null && !constructorAttribute && !importAttribute)
                return;

            if (_container.ContainsKey(type))
                throw new Exception($"{type} is already registered");

            InstanceEntity instanceEntity = null;

            if (constructorAttribute && importAttribute)
                throw new Exception("Only a constructor attribute or only a property attribute can be set.");

            if (constructorAttribute)
                instanceEntity = new InstanceEntityWithConstructor(instanceType);
            else if (importAttribute)
                instanceEntity = new InstanceEntityWithProperties(instanceType);
            else if (exportAttribute != null)
                instanceEntity = new InstanceEntity(instanceType);

            _container.Add(type, instanceEntity);
        }

        public object CreateInstance(Type type)
        {
            if (type == null)
                throw new ArgumentNullException();

            _container.TryGetValue(type, out var instanceType);

            if (instanceType == null)
                throw new Exception($"Type {type} isn't registered in container.");

            return CreateInstance(instanceType);
        }

        public T CreateInstance<T>() where T : class
            => (T)CreateInstance(typeof(T));

        private object CreateInstance(InstanceEntity creator)
        {
            if (creator == null)
                throw new ArgumentNullException();

            switch (creator)
            {
                case InstanceEntityWithConstructor constructorCreator:
                    {
                        var objForType = constructorCreator.ConstructorParameterType
                            .Select(x => CreateInstance(x.ParameterType)).ToArray();
                        return Activator.CreateInstance(creator.Type, objForType);
                    }
                case InstanceEntityWithProperties propertiesCreator:
                    {
                        var objForType = Activator.CreateInstance(creator.Type);
                        foreach (var prop in propertiesCreator.PropertiesType)
                            prop.SetValue(objForType, CreateInstance(prop.PropertyType));
                        return objForType;
                    }
                case InstanceEntity c:
                    return Activator.CreateInstance(creator.Type);
                default:
                    throw new Exception();
            }
        }
    }

}
