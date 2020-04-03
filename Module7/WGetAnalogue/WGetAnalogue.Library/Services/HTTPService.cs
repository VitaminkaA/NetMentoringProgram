using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WGetAnalogue.Library.Services
{
    public class HTTPService
    {
        private readonly HttpClient _client;

        public HTTPService()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _client = new HttpClient();
        }

        public async Task<string> GetSite(string url)
        {
            var uri = new Uri(url ?? throw new ArgumentNullException());
            var res = await _client.GetAsync(uri);
            byte[] buffer = await res.Content.ReadAsByteArrayAsync();

            Encoding encoding = Encoding.GetEncoding("windows-1251");

            return encoding.GetString(buffer,0,buffer.Length);
        }
    }
}
