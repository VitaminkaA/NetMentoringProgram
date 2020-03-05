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
        private readonly Dictionary<Type, Instance> _container = new Dictionary<Type, Instance>();

        public void AddAssembly(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException();

            foreach (var type in assembly.DefinedTypes)
                AddType(type);
        }

        public void AddType(Type type)
            => AddType(type, type);

        public void AddType(Type type1, Type type2)
        {
            if (type1 == null || type2 == null)
                throw new ArgumentNullException();

            var exportAttribute = type1.GetCustomAttribute<ExportAttribute>();
            var constructorAttribute = type1.GetCustomAttribute<ImportConstructorAttribute>() != null;
            var importAttribute = type1.GetProperties().Any(x => x.GetCustomAttribute<ImportAttribute>() != null);

            if (exportAttribute != null)
                type2 = exportAttribute.Type ?? type2;

            if (exportAttribute == null && !constructorAttribute && !importAttribute)
                return;

            if (_container.ContainsKey(type2))
                throw new Exception($"{type2} is already registered");

            Instance creator = null;
            if (constructorAttribute && importAttribute)
                throw new Exception("Only a constructor attribute or only a property attribute can be set.");
            if (constructorAttribute)
                creator = new InstanceWithConstructor(type1);
            if (importAttribute)
                creator = new InstanceWithProperties(type1);
            if (exportAttribute != null)
                creator = new Instance(type1);

            _container.Add(type2, creator);
        }

        public object CreateInstance(Type type)
        {
            if (type == null)
                throw new ArgumentNullException();

            _container.TryGetValue(type, out var creator);

            if (creator == null)
                throw new Exception($"Type {type} isn't registered in container.");

            return CreateInstance(creator);
        }

        public T CreateInstance<T>() where T : class
            => (T)CreateInstance(typeof(T));

        private object CreateInstance(Instance creator)
        {
            if (creator == null)
                throw new ArgumentNullException();

            switch (creator)
            {
                case InstanceWithConstructor constructorCreator:
                    {
                        var objForType = constructorCreator.ConstructorParameterType
                            .Select(x => CreateInstance(x.ParameterType)).ToArray();
                        return Activator.CreateInstance(creator.Type, objForType);
                    }
                case InstanceWithProperties propertiesCreator:
                    {
                        var objForType = Activator.CreateInstance(creator.Type);
                        foreach (var prop in propertiesCreator.PropertiesType)
                            prop.SetValue(objForType, CreateInstance(prop.PropertyType));
                        return objForType;
                    }
                case Instance c:
                    return Activator.CreateInstance(creator.Type);
                default:
                    throw new Exception();
            }
        }
    }

}
