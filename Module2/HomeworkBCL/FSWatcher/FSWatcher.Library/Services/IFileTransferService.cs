using System;
using System.Collections.Generic;
using System.Text;
using FSWatcher.Library.Entity;

namespace FSWatcher.Library.Services
{
    internal interface IFileTransferService
    {
        NewFileInfo GetFileInfo(string path);
        void MoveFolder(string path, string newPath);
    }
}
