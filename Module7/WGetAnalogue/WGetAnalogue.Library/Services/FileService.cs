using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WGetAnalogue.Library.Services
{
    internal class FileService : IFileService
    {
        public async Task SaveByteArrayAsync(string path, byte[] content)
        {
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir ?? throw new ArgumentNullException()))
                Directory.CreateDirectory(dir);

            await File.WriteAllBytesAsync(path, content);
        }

        public async Task SaveStringAsync(string path, string content)
        {
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir ?? throw new ArgumentNullException()))
                Directory.CreateDirectory(dir);

            await File.WriteAllTextAsync(path, content);
        }
    }
}
