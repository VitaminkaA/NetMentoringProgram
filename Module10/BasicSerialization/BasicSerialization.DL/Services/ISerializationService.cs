using System.IO;

namespace BasicSerialization.Core.Services
{
    public interface ISerializationService
    {
        public T Deserialize<T>(Stream stream);

        public void Serialize<T>(T item, Stream stream);
    }
}
