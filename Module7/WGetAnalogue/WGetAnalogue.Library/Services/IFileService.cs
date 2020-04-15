using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WGetAnalogue.Library.Services
{
    public interface IFileService
    {
        Task SaveByteArrayAsync(string path, byte[] content);
        Task SaveStringAsync(string path, string content);
    }
}
