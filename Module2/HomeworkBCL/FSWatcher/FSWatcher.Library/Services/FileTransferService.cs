using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FSWatcher.Library.Entity;

namespace FSWatcher.Library.Services
{
    internal class FileTransferService : IFileTransferService
    {
        public NewFileInfo GetFileInfo(string path)
        {
            if (path == null)
                throw new ArgumentNullException();

            var file = new FileInfo(path);

            if (!file.Exists)
                throw new FileNotFoundException();

            return new NewFileInfo
            {
                Path = file.FullName,
                Name = file.Name,
                DateTime = file.CreationTime
            };
        }

        public void MoveFolder(string path, string newPath)
        {
            if (path == null || newPath == null)
                throw new ArgumentNullException();

            var file1Info = new FileInfo(path);
            var file2Info = new FileInfo(newPath);

            if (!file1Info.Exists)
                throw new FileNotFoundException();

            if (!Directory.Exists(file2Info.DirectoryName))
                Directory.CreateDirectory(file2Info.DirectoryName);

            File.Move(path, newPath);
        }
    }
}
