using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGetAnalogue.Library.Services
{
    internal class ParseService : IParseService
    {
        private readonly IHtmlParser _parseService;

        public ParseService()
            => _parseService = new HtmlParser();

        public async Task<IEnumerable<string>> GetAllLinks(string source)
        {
            if (string.IsNullOrEmpty(source))
                new ArgumentNullException();

            var document = await _parseService.ParseDocumentAsync(source);
            return document.QuerySelectorAll("a")
                .Select(x => x.GetAttribute("href"));
        }
    }
}
