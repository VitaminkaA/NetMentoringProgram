using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Exceptions
{
    public enum RepositoryExceptionType
    {
        NotFound,
        NoRightsToExecuteRequest
    }
}
