using System;
using System.Collections.Generic;
using System.Text;

namespace FSWatcher.Library.Services
{
    internal interface IFolderWatcherProvider : IDisposable
    {
        event Action<string> Created;
        void StartWatching(string path);
    }
}
