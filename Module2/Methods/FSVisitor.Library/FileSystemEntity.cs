using System.IO;


namespace FSVisitor.Library
{
    public class FileSystemEntity
    {
        public FileSystemEntity(FileSystemInfo fileSystemInfo) 
            => FileSystemInfo = fileSystemInfo;

        public FileSystemInfo FileSystemInfo { get;}

        public bool Skip { get; set; }
        public bool StopSearch { get; set; }
    }
}
