using System.Xml.Serialization;

namespace BasicSerialization.DL.Models
{
    public enum Genre
    {
        [XmlEnum]
        Computer,
        [XmlEnum]
        Fantasy,
        [XmlEnum]
        Romance,
        [XmlEnum]
        Horror,
        [XmlEnum("Science Fiction")]
        ScienceFiction

    }
}
