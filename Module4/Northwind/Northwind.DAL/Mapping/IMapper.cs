using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Northwind.DAL.Mapping
{
    public interface IMapper
    {
        T Map<T>(IDataReader reader) where T : new();
    }
}
