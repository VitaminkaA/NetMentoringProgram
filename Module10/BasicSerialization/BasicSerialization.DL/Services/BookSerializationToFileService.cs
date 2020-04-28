using System;
using System.Collections.Generic;
using System.IO;
using BasicSerialization.DL.Models;

namespace BasicSerialization.Core.Services
{
    public class BookSerializationToFileService : IBookSerializationToFileService
    {
        private readonly ISerializationService _serializer;
        public BookSerializationToFileService(ISerializationService serializationService) => 
            _serializer = serializationService ?? throw new ArgumentNullException();

        public Book[] Deserialize(string path)
        {
            if (!File.Exists(path))
                throw new Exception();

            return _serializer.Deserialize<Book[]>(new FileStream(path, FileMode.Open));
        }

        public void Serialize(Book[] books, string path)
        {
            if (File.Exists(path))
                throw new Exception();

            _serializer.Serialize(books ?? throw new ArgumentNullException(),
                new FileStream(path, FileMode.Create));
        }
    }
}
