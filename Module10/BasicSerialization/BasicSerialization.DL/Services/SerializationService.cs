using System.IO;
using System.Xml.Serialization;

namespace BasicSerialization.Core.Services
{
    public class SerializationService : ISerializationService
    {
        public T Deserialize<T>(Stream stream) =>
            (T)new XmlSerializer(typeof(T)).Deserialize(stream);

        public void Serialize<T>(T item, Stream stream) =>
            new XmlSerializer(typeof(T)).Serialize(stream, item);
    }
}
