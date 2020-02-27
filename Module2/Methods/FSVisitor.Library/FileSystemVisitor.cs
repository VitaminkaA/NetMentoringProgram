using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FSVisitor.Library
{
    public class FileSystemVisitor
    {
        public Predicate<FileSystemInfo> Filter { get; }

        public event Action Start, Finish;

        public event Action<FileSystemEntity> FileFound, DirectoryFound, FilteredFileFound, FilteredDirectoryFound;

        public FileSystemVisitor() { }

        public FileSystemVisitor(Predicate<FileSystemInfo> filter)
            => Filter = filter;

        public IEnumerable<FileSystemInfo> Visit(DirectoryInfo dir)
        {
            if (!dir.Exists)
                throw new DirectoryNotFoundException();

            CallStartEvent();

            var stack = new Stack<FileSystemInfo>();
            stack.Push(dir);

            while (stack.Any())
            {
                var element = stack.Pop();
                var elForCheck = new FileSystemEntity(element);
                var directory = element as DirectoryInfo;
                bool filterRes;
                if (directory != null)
                {
                    filterRes = CheckElement(elForCheck, () => CallDirectoryFound(elForCheck),
                        () => CallFilteredDirectoryFound(elForCheck));
                    foreach (var childrenElement in directory.EnumerateFileSystemInfos().Reverse())
                        stack.Push(childrenElement);
                }
                else
                    filterRes = CheckElement(elForCheck, () => CallFileFound(elForCheck),
                        () => CallFilteredFileFound(elForCheck));

                if (elForCheck.StopSearch)
                    break;
                if (!filterRes || elForCheck.Skip)
                    continue;
                yield return elForCheck.FileSystemInfo;
            }
            CallFinishEvent();
        }

        private bool CheckElement(FileSystemEntity fileInfo, Action itemFound, Action filteredItemFound)
        {
            itemFound();
            if (Filter == null) return true;

            var resFilter = Filter.Invoke(fileInfo.FileSystemInfo);
            if (resFilter)
                filteredItemFound();

            return resFilter;
        }

        private void CallStartEvent()
            => Start?.Invoke();

        private void CallFinishEvent()
            => Finish?.Invoke();

        private void CallFileFound(FileSystemEntity arg)
            => FileFound?.Invoke(arg);

        private void CallDirectoryFound(FileSystemEntity arg)
            => DirectoryFound?.Invoke(arg);

        private void CallFilteredFileFound(FileSystemEntity arg)
            => FilteredFileFound?.Invoke(arg);
        private void CallFilteredDirectoryFound(FileSystemEntity arg)
            => FilteredDirectoryFound?.Invoke(arg);
    }
}