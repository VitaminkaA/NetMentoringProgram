using FSVisitor.Library;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FSVisitor.Library.Entity;
using Xunit;

namespace FSVisitor.UnitTests
{
    public class FileSystemVisitorTests
    {
        [Fact]
        public void FileSystemInfoTraversalTree_PathIsNull_ReturnNullReferenceException()
        {
            // Arrange
            var visitor = new FakeFileSystemVisitor();

            // Act, Assert
            Assert.Throws<NullReferenceException>(() =>
                visitor.Visit(null).ToArray());
        }

        [Fact]
        public void FileSystemInfoTraversalTree_ExistentDirectory_ReturnNotEmptyCollection()
        {
            // Arrange
            var visitor = new FakeFileSystemVisitor();

            // Act
            var res = visitor.Visit("").ToArray();

            //Assert
            Assert.NotEmpty(res);
        }

        [Fact]
        public void FileSystemInfoTraversalTree_WithFilter_ReturnOnlyDirectory()
        {
            // Arrange
            var visitor = new FakeFileSystemVisitor(x => x.Type == FileSystemEntryType.Directory);

            // Act
            var res = visitor.Visit("").ToArray();

            //Assert
            Assert.All(res, (x) => Assert.True(x.Type == FileSystemEntryType.Directory));
        }

        [Fact]
        public void FileSystemInfoTraversalTree_WithSubscriptionToStartAndFinishEvents_InvokeEvents()
        {
            // Arrange
            var visitor = new FakeFileSystemVisitor();
            var start = false;
            var finish = false;
            visitor.Start += () => start = true;
            visitor.Finish += () => finish = true;

            // Act
            visitor.Visit("").ToArray();

            //Assert
            Assert.True(start);
            Assert.True(finish);
        }

        [Fact]
        public void FileSystemInfoTraversalTree_IfFilteringIsOff_DoNotInvokeFilteredEvents()
        {
            // Arrange
            var visitor = new FakeFileSystemVisitor();
            var filteredFileFound = false;
            var filteredDirectoryFound = false;
            visitor.FilteredFileFound += (x) => filteredFileFound = true;
            visitor.FilteredDirectoryFound += (x) => filteredDirectoryFound = true;

            // Act
            visitor.Visit("").ToArray();

            //Assert
            Assert.False(filteredFileFound);
            Assert.False(filteredDirectoryFound);
        }

        [Fact]
        public void FileSystemInfoTraversalTree_WithFilter_DoNotInvokeFilteredFileFound()
        {
            // Arrange
            var visitor = new FakeFileSystemVisitor(x => x.Type == FileSystemEntryType.Directory);
            var fileFound = false;
            var directoryFound = false;
            var filteredFileFound = false;
            var filteredDirectoryFound = false;
            visitor.FileFound += x => fileFound = true;
            visitor.DirectoryFound += x => directoryFound = true;
            visitor.FilteredFileFound += (x) => filteredFileFound = true;
            visitor.FilteredDirectoryFound += (x) => filteredDirectoryFound = true;

            // Act
            visitor.Visit("").ToArray();

            //Assert
            Assert.True(fileFound);
            Assert.True(directoryFound);
            Assert.False(filteredFileFound);
            Assert.True(filteredDirectoryFound);
        }

        [Fact]
        public void FileSystemInfoTraversalTree_WithFileFoundEvent_SkipFilesStartsWithPrefix()
        {
            // Arrange
            var visitor = new FakeFileSystemVisitor();
            var prefix = "3";
            visitor.FileFound += (x) =>
            {
                if (x.Name.StartsWith(prefix))
                    x.Skip = true;
            };

            // Act
            var res = visitor.Visit("").ToArray();

            //Assert
            Assert.All(res, (x) =>
                    Assert.True(x.Type != FileSystemEntryType.File || !x.Name.StartsWith(prefix)));
        }

        [Fact]
        public void FileSystemInfoTraversalTree_WithDirectoryFoundEvent_SkipDirectoryStartsWithPrefix()
        {
            // Arrange
            var visitor = new FakeFileSystemVisitor();
            var prefix = "1";
            visitor.DirectoryFound += (x) =>
            {
                if (x.Name.StartsWith(prefix))
                    x.Skip = true;
            };

            // Act
            var res = visitor.Visit("").ToArray();

            //Assert
            Assert.All(res, (x) =>
                Assert.True(x.Type != FileSystemEntryType.Directory || !x.Name.StartsWith(prefix)));
        }

        #region Setup

        public class FakeFileSystemVisitor : FileSystemVisitor
        {

            public FakeFileSystemVisitor()
                => InitializeFileSystemProvider();

            public FakeFileSystemVisitor(Predicate<FileSystemEntry> filter) : base(filter)
                => InitializeFileSystemProvider();

            private void InitializeFileSystemProvider() =>
                FileSystemProvider = Mock.Of<IFileSystemProvider>(x
                    => x.EnumerateFileSystemEntries(It.IsAny<string>()) == new List<FileSystemEntry>
                    {
                        new FileSystemEntry
                        {
                            Name = "1FileName1",
                            FullName = "FileFullName1",
                            CreationTime = DateTime.MinValue,
                            Extension = ".fileextension1",
                            Type = FileSystemEntryType.File
                        },
                        new FileSystemEntry
                        {
                            Name = "2FileName2",
                            FullName = "FileFullName2",
                            CreationTime = DateTime.MinValue,
                            Extension = ".fileextension2",
                            Type = FileSystemEntryType.File
                        },
                        new FileSystemEntry
                        {
                            Name = "3FileName3",
                            FullName = "FileName3",
                            CreationTime = DateTime.MinValue,
                            Extension = ".fileExtension3",
                            Type = FileSystemEntryType.File
                        },
                        new FileSystemEntry
                        {
                            Name = "1FolderName1",
                            FullName = "FolderFullName1",
                            CreationTime = DateTime.MinValue,
                            Extension = ".folderExtension1",
                            Type = FileSystemEntryType.Directory
                        },
                        new FileSystemEntry
                        {
                            Name = "2FolderName2",
                            FullName = "FolderFullName2",
                            CreationTime = DateTime.MinValue,
                            Extension = ".folderExtension2",
                            Type = FileSystemEntryType.Directory
                        },
                    });
        }
    }
    #endregion
}
