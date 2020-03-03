using System;
using FSWatcher.Library.Entity;
using System.IO;
using System.Linq;
using System.Text;
using FSWatcher.Library.Services;

namespace FSWatcher.Library
{
    public class FolderWatcherService : IDisposable
    {
        private readonly IFolderWatcherProvider _folderWatcher;
        private readonly IFileTransferService _fileTransferService;
        private readonly TrackedFolder _folder;

        public event Action<NewFileInfo> NewFileFound;
        public event Action RuleFound, RuleNotFound, SuccessfulFileTransfer;

        public FolderWatcherService(TrackedFolder folder)
        {
            _folder = folder ?? throw new ArgumentNullException();

            _folderWatcher = new FolderWatcherProvider();
            _folderWatcher.Created += NewFile;
            _fileTransferService = new FileTransferService();
        }

        public void StartWatching() =>
            _folderWatcher.StartWatching(_folder.Path
                                         ?? throw new NullReferenceException());

        private void NewFile(string fullPath)
        {
            if (fullPath == null)
                throw new ArgumentNullException();

            var newFileInfo = _fileTransferService.GetFileInfo(fullPath);

            CallEvent(NewFileFound, newFileInfo);

            var (regex, value) = _folder.Templates.FirstOrDefault(t
                => t.Key.IsMatch(newFileInfo.Name));

            CallEvent(regex == null ? RuleNotFound : RuleFound);

            var destinationFolder = value ?? _folder.DefaultMoveFolder;

            if (_folder.IncludeMoveDate)
                newFileInfo.Name = $"({DateTimeOffset.Now.Date.ToShortDateString().Replace('/', '-')}){ newFileInfo.Name}";
            if (_folder.IncludeNumbering)
                newFileInfo.Name = $"({_folder.Count++}){newFileInfo.Name}";
            _fileTransferService.MoveFolder(fullPath, Path.Combine(destinationFolder, newFileInfo.Name));

            CallEvent(SuccessfulFileTransfer);
        }

        public void Dispose()
            => _folderWatcher.Dispose();

        private static void CallEvent(Action action)
            => action?.Invoke();

        private static void CallEvent<T>(Action<T> action, T item1)
            => action?.Invoke(item1);
    }
}
