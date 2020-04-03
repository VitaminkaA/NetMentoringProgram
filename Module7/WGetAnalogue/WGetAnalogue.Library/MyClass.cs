using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WGetAnalogue.Library.Services;

namespace WGetAnalogue.Library
{
    public class MyClass
    {
        public MyClass()
        {

        }

        public async Task<string> GetText(string path)
        {
            var hTTPService = new HTTPService();
            var res = await hTTPService.GetSite(path);
            return res;
        }
    }
}
