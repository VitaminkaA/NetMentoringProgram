using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGetAnalogue.Library.Models;
using WGetAnalogue.Library.Services;

namespace WGetAnalogue.Library
{
    public class SiteLocalCopy
    {
        private readonly IParseService _parseService;
        private readonly IFileService _fileService;
        private readonly IHTTPService _httpService;

        public event Action<Uri> Start;
        public event Action<Uri> Finish;

        private readonly string _contentType = "html";

        public SiteLocalCopy(
            IFileService fileService = null,
            IParseService parseService = null,
            IHTTPService httpService = null)
        {
            _parseService = parseService ?? new ParseService();
            _fileService = fileService ?? new FileService();
            _httpService = httpService ?? new HTTPService();
        }

        public async Task CreateCopyAsync(string path, string pathDir,
            int depth = 0,
            IEnumerable<string> allowedExtensions = null,
            TransitionRestrictionsEnum transitionRestrictionsEnum = TransitionRestrictionsEnum.NoTransitionRestrictions)
        {
            var startUri = new Uri(path ?? throw new ArgumentNullException());
            var domainName = startUri.Scheme + "://" + startUri.Authority;
            ICollection<Uri> visitedPages = new List<Uri>();
            var treeNodes = new Stack<Uri>();
            treeNodes.Push(startUri);
            while (treeNodes.Any())
            {
                var uriNode = treeNodes.Pop();
                Start?.Invoke(uriNode);
                var res = await _httpService.GetContentAsync(uriNode);
                visitedPages.Add(uriNode);
                if (res.CharSet != null)
                {
                    var resStr = Encoding.GetEncoding(res.CharSet)
                        .GetString(res.Content);

                    if (CheckFileExtension(res.Type, allowedExtensions))
                        await _fileService.SaveStringAsync(GetPathToSave(uriNode, pathDir, res.Type), resStr);
                    if (depth > 0 && res.Type == _contentType)
                    {
                        foreach (var par in await _parseService?.GetAllLinks(resStr))
                        {
                            if (string.IsNullOrEmpty(par))
                                continue;

                            var newUri = GetUri(par, domainName);
                            if (CheckDomain(newUri, startUri, transitionRestrictionsEnum) && !visitedPages.Any(x => x == newUri))
                                treeNodes.Push(newUri);
                        }
                        depth--;
                    }
                }
                else
                    if (CheckFileExtension(res.Type, allowedExtensions))
                    await _fileService.SaveByteArrayAsync(GetPathToSave(uriNode, pathDir, res.Type), res.Content);
                Finish?.Invoke(uriNode);
            }
        }

        private Uri GetUri(string path, string domainName)
        {
            if (!path.StartsWith("http"))
                path = domainName + path;

            return new Uri(path);
        }

        private string GetPathToSave(Uri uriNode, string pathDir, string fileType)
        {
            var partsPath = uriNode.LocalPath.Split("/");
            foreach (var part in partsPath)
                pathDir = Path.Combine(pathDir, part);

            if (string.IsNullOrWhiteSpace(Path.GetExtension(pathDir)))
                pathDir = Path.Combine(pathDir, Path.GetFileName(pathDir) + $".{fileType}");

            return pathDir;
        }

        private bool CheckFileExtension(string type, IEnumerable<string> allowedExtensions)
            => allowedExtensions == null
            ? true
            : allowedExtensions.Any(x => x == type);

        private bool CheckDomain(Uri newUri, Uri startUri, TransitionRestrictionsEnum transitionRestrictionsEnum)
            => transitionRestrictionsEnum switch
            {
                TransitionRestrictionsEnum.InsideTheCurrentDomain
                    when !($"{newUri.Scheme}://{newUri.Authority}" == $"{startUri.Scheme}://{startUri.Authority}") =>
                    false,
                TransitionRestrictionsEnum.NoHigherThanTheOriginalPath
                    when !newUri.AbsolutePath.StartsWith(startUri.AbsolutePath) =>
                    false,
                _ => true,
            };
    }
}
