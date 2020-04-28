using System.Collections.Generic;
using BasicSerialization.DL.Models;

namespace BasicSerialization.Core.Services
{
    public interface IBookSerializationToFileService
    {
        public Book[] Deserialize(string path);

        public void Serialize(Book[] books, string path);
    }
}
