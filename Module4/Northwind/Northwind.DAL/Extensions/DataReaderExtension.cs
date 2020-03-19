using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Northwind.DAL.Mapping;

namespace Northwind.DAL.Extensions
{
    public static class DataReaderExtension
    {
        public static IEnumerable<T> ReadCollection<T>(this IDataReader reader, IMapper mapper)
            where T : new()
        {
            var items = new List<T>();
            while (reader.Read())
                items.Add(mapper.Map<T>(reader));
            return items;
        }
    }
}
