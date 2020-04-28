using System;
using BasicSerialization.ConsoleApp.Settings;
using BasicSerialization.Core.Services;
using Microsoft.Extensions.Options;

namespace BasicSerialization.ConsoleApp
{
    public class Application
    {
        private readonly BooksSettings _settings;
        private readonly IBookSerializationToFileService _service;
        public Application(IOptions<BooksSettings> options, IBookSerializationToFileService service)
        {
            _settings = options?.Value ?? throw new ArgumentNullException();
            _service = service ?? throw new ArgumentNullException();
        }
        public void Run()
        {
            var books = _service.Deserialize(_settings.FilePathForDeserialization);
            _service.Serialize(books,_settings.FilePathForSerialization);
        }

    }
}
