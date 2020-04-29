using BasicSerialization.Core.Models;

namespace BasicSerialization.Core.Services
{
    public interface ICatalogSerializationToFileService
    {
        public Catalog Deserialize(string path);

        public void Serialize(Catalog catalog, string path);
    }
}
