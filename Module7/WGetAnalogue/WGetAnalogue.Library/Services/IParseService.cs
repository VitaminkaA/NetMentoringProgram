using System.Collections.Generic;
using System.Threading.Tasks;

namespace WGetAnalogue.Library.Services
{
    public interface IParseService
    {
        Task<IEnumerable<string>> GetAllLinks(string source);
    }
}
