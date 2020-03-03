using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace FSWatcher.Library.Services
{
    internal class FolderWatcherProvider : IFolderWatcherProvider
    {
        private readonly FileSystemWatcher _fileSystemWatcher;

        public event Action<string> Created;

        public FolderWatcherProvider()
        {
            _fileSystemWatcher = new FileSystemWatcher { NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName };
            _fileSystemWatcher.Created += OnChanged;
        }

        public void StartWatching(string path)
        {
            _fileSystemWatcher.Path = path
                                      ?? throw new ArgumentNullException();
            _fileSystemWatcher.EnableRaisingEvents = true;
        }


        private void OnChanged(object sender, FileSystemEventArgs eventArgs)
            => Created?.Invoke(eventArgs.FullPath);

        public void Dispose()
            => _fileSystemWatcher.Dispose();
    }
}
