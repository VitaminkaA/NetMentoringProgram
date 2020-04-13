using System;
using System.Collections.Generic;
using System.Text;

namespace HttpHandler.DAL.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
