using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Northwind.DAL.Extensions
{
    public static class DbCommandExtension
    {
        public static DbParameter CreateParameter(this DbCommand command, string name, object value)
        {
            var par = command.CreateParameter();
            par.ParameterName = name ?? throw new ArgumentNullException();
            par.Value = value?? DBNull.Value;
            return par;
        }
    }
}
