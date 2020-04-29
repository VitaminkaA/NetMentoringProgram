using System;
using System.IO;
using BasicSerialization.Core.Models;

namespace BasicSerialization.Core.Services
{
    public class CatalogSerializationToFileService : ICatalogSerializationToFileService
    {
        private readonly ISerializationService _serializer;
        public CatalogSerializationToFileService(ISerializationService serializationService) => 
            _serializer = serializationService ?? throw new ArgumentNullException();

        public Catalog Deserialize(string path)
        {
            if (!File.Exists(path))
                throw new Exception();

            return _serializer.Deserialize<Catalog>(new FileStream(path, FileMode.Open));
        }

        public void Serialize(Catalog catalog, string path)
        {
            if (File.Exists(path))
                throw new Exception();

            _serializer.Serialize(catalog ?? throw new ArgumentNullException(),
                new FileStream(path, FileMode.Create));
        }
    }
}
