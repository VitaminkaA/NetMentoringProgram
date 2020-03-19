using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Exceptions
{
    public class RepositoryException : Exception
    {
        public readonly RepositoryExceptionType Type;

        public RepositoryException(string message)
            : base(message) { }

        public RepositoryException(RepositoryExceptionType type)
            : this(type, null) { }

        public RepositoryException(RepositoryExceptionType type, string message) : base(message)
            => Type = type;
    }
}
