using System;
using System.Xml.Serialization;
using BasicSerialization.DL.Models;

namespace BasicSerialization.Core.Models
{
    [XmlRoot("catalog", Namespace = "http://library.by/catalog", IsNullable = false)]
    public class Catalog
    {
        [XmlAttribute("date", DataType = "date")]
        public DateTime Date { get; set; }

        [XmlElement("book")]
        public Book[] Book { get; set; }
    }
}
