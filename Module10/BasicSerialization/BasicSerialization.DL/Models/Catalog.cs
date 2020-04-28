using System;
using BasicSerialization.DL.Models;

namespace BasicSerialization.Core.Models
{
    public class Catalog
    {
        public DateTime Date { get; set; }
        public Book[] Books { get; set; }
    }
}
