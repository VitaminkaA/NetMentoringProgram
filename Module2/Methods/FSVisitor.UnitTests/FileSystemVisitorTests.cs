using FSVisitor.Library;
using Moq;
using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace FSVisitor.UnitTests
{
    public class FileSystemVisitorTests
    {
        private readonly DirectoryInfo _directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

        [Fact]
        public void FileSystemInfoTraversalTree_NonExistentDirectory_ReturnDirectoryNotFoundException()
        {
            // Arrange
            var visitor = new FileSystemVisitor();

            // Act, Assert
            Assert.Throws<DirectoryNotFoundException>(() =>
                visitor.Visit(new DirectoryInfo(@"dfdfsdfdsf")).ToArray());
        }

        [Fact]
        public void FileSystemInfoTraversalTree_ExistentDirectory_ReturnNotEmptyCollection()
        {
            // Arrange
            var visitor = new FileSystemVisitor();

            // Act
            var res = visitor.Visit(_directory).ToArray();

            //Assert
            Assert.NotEmpty(res);
        }

        [Fact]
        public void FileSystemInfoTraversalTree_WithFilter_ReturnOnlyDirectory()
        {
            // Arrange
            var visitor = new FileSystemVisitor(x => x.Attributes == FileAttributes.Directory);

            // Act
            var res = visitor.Visit(_directory).ToArray();

            //Assert
            Assert.All(res, (x) => Assert.IsType<DirectoryInfo>(x));
        }

        [Fact]
        public void FileSystemInfoTraversalTree_WithSubscriptionToStartAndFinishEvents_InvokeEvents()
        {
            // Arrange
            var visitor = new FileSystemVisitor();
            var start = false;
            var finish = false;
            visitor.Start += () => start = true;
            visitor.Finish += () => finish = true;

            // Act
            visitor.Visit(_directory).ToArray();

            //Assert
            Assert.True(start);
            Assert.True(finish);
        }

        [Fact]
        public void FileSystemInfoTraversalTree_IfFilteringIsOff_DoNotInvokeFilteredEvents()
        {
            // Arrange
            var visitor = new FileSystemVisitor();
            var filteredFileFound = false;
            var filteredDirectoryFound = false;
            visitor.FilteredFileFound += (x) => filteredFileFound = true;
            visitor.FilteredDirectoryFound += (x) => filteredDirectoryFound = true;

            // Act
            visitor.Visit(_directory).ToArray();

            //Assert
            Assert.True(!filteredFileFound);
            Assert.True(!filteredDirectoryFound);
        }

        [Fact]
        public void FileSystemInfoTraversalTree_WithFilter_DoNotInvokeFilteredFileFound()
        {
            // Arrange
            var visitor = new FileSystemVisitor(x => x.Attributes == FileAttributes.Directory);
            var fileFound = false;
            var directoryFound = false;
            var filteredFileFound = false;
            var filteredDirectoryFound = false;
            visitor.FileFound += x => fileFound = true;
            visitor.DirectoryFound += x => directoryFound = true;
            visitor.FilteredFileFound += (x) => filteredFileFound = true;
            visitor.FilteredDirectoryFound += (x) => filteredDirectoryFound = true;

            // Act
            visitor.Visit(_directory).ToArray();

            //Assert
            Assert.True(fileFound);
            Assert.True(directoryFound);
            Assert.True(!filteredFileFound);
            Assert.True(filteredDirectoryFound);
        }

        [Fact]
        public void FileSystemInfoTraversalTree_WithFileFoundEvent_SkipFilesStartsWithPrefix()
        {
            // Arrange
            var visitor = new FileSystemVisitor();
            var prefix = "Microsoft";
            visitor.FileFound += (x) =>
            {
                if (x.FileSystemInfo.Name.StartsWith(prefix))
                    x.Skip = true;
            };

            // Act
            var res = visitor.Visit(_directory).ToArray();

            //Assert
            Assert.All(res, (x) =>
                    Assert.True(!(x is FileInfo) || !x.Name.StartsWith(prefix)));
        }

        [Fact]
        public void FileSystemInfoTraversalTree_WithDirectoryFoundEvent_SkipFilesStartsWithPrefix()
        {
            // Arrange
            var visitor = new FileSystemVisitor();
            var prefix = "zh";
            visitor.DirectoryFound += (x) =>
            {
                if (x.FileSystemInfo.Name.StartsWith(prefix))
                    x.Skip = true;
            };

            // Act
            var res = visitor.Visit(_directory).ToArray();

            //Assert
            Assert.All(res, (x) =>
                Assert.True(!(x is DirectoryInfo) || !x.Name.StartsWith(prefix)));
        }
    }
}
