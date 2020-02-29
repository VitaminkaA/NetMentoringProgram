using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FSVisitor.Library;
using Xunit;

namespace FSVisitor.UnitTests
{
    public class FileSystemProviderTests
    {
        [Fact]
        public void FileSystemInfoTraversalTree_PathIsNull_NullReferenceException()
        {
            // Arrange
            var visitor = new FileSystemProvider();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                visitor.EnumerateFileSystemEntries(null).ToArray());
        }

        [Fact]
        public void FileSystemInfoTraversalTree_NonExistentPath_DirectoryNotFoundException()
        {
            // Arrange
            var visitor = new FileSystemProvider();

            // Act, Assert
            Assert.Throws<DirectoryNotFoundException>(() =>
                visitor.EnumerateFileSystemEntries("fake path123").ToArray());
        }
    }
}
