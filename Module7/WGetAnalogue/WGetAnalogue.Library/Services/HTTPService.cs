using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WGetAnalogue.Library.Models;

namespace WGetAnalogue.Library.Services
{
    internal class HTTPService : IHTTPService
    {
        private readonly HttpClient _client;

        public HTTPService()
            => _client = new HttpClient();

        public async Task<ContentModel> GetContentAsync(Uri path)
        {
            using var response = await _client.GetAsync(path);

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var contentType = response.Content.Headers.ContentType;

            return new ContentModel
            {
                Type = contentType.MediaType
                    .Split("/")
                    .LastOrDefault(),
                Content = await response.Content.ReadAsByteArrayAsync(),
                CharSet = contentType.CharSet,
            };
        }
    }
}
