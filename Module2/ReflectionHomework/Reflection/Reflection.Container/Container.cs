using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Reflection.Container.Attributes;
using Reflection.Container.Services;

namespace Reflection.Container
{
    public class Container
    {
        private readonly Dictionary<Type, ICreator> _container = new Dictionary<Type, ICreator>();

        public void AddType(Type type)
        {
            if (type == null)
                throw new ArgumentException();

            _container.Add(type, GetCreator(type));
        }

        //public void AddType(Type type1, Type type2)
        //{

        //    _container.Add(type1, type2);
        //}

        //public object CreateInstance(Type type)
        //{
        //    if (type == null)
        //        throw new ArgumentNullException(nameof(type));

        //    if (_container.TryGetValue(type, out var createdObject))
        //        return createdObject.CreateInstance();
        //    else
        //        throw new Exception();
        //}

        //public T CreateInstance<T>()
        //{
        //    return (T)CreateInstance(typeof(T));
        //}

        private ICreator GetCreator(Type type)
        {
            if (type == null)
                throw new ArgumentNullException();

            var isConstructorAttribute = false;
            var isImportAttribute = false;
            var isExportAttribute = false;

            foreach (var attribute in type.GetCustomAttributes())
                switch (attribute)
                {
                    case ImportConstructorAttribute _:
                        isConstructorAttribute = true;
                        break;
                    case ImportAttribute _:
                        isImportAttribute = true;
                        break;
                    case ExportAttribute _:
                        isExportAttribute = true;
                        break;
                }

            if (isConstructorAttribute && isImportAttribute)
                throw new Exception();

            ICreator creator;

            if (isConstructorAttribute)
                creator = new ConstructorCreator(type);



            return null;
        }
    }
}
