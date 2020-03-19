using System;
using System.Data;
using System.Reflection;
using System.Linq;

namespace Northwind.DAL.Mapping
{
    public class Mapper : IMapper
    {
        public T Map<T>(IDataReader reader) where T : new()
        {
            if (reader == null)
                throw new ArgumentNullException();

            var propertiesInfo = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var columnNames = Enumerable.Range(0, reader.FieldCount)
                .Select(reader.GetName)
                .ToList();

            var obj = new T();

            foreach (var property in propertiesInfo)
            {
                if (!columnNames.Any(s => s.Equals(property.Name, StringComparison.OrdinalIgnoreCase)))
                    continue;
                try
                {
                    property.SetValue(obj, reader[property.Name]);
                }
                catch (ArgumentException)
                {
                    property.SetValue(obj, default(T));
                }
            }

            return obj;
        }
    }
}
