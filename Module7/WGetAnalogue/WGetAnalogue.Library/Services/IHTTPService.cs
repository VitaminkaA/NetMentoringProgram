using System;
using System.Threading.Tasks;
using WGetAnalogue.Library.Models;

namespace WGetAnalogue.Library.Services
{
    public interface IHTTPService
    {
        Task<ContentModel> GetContentAsync(Uri path);
    }
}
