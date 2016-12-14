using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DiffPlex;
using DiffPlex.DiffBuilder.Model;
using Testo.Extensibility;
using Testo.FileSystem;
// ReSharper disable UnusedParameter.Global

namespace Testo.TestDataBased
{
    public static class TestDataAssert
    {
        public static void DirectoriesAreEqual(
            IFileSystemDirectory expectedDataDirectory,
            IFileSystemDirectory actualDataDirectory,
            string assertion = "Directories are equal")
        {
            var expectedFileSystemEntries = GetFilesWithAttributes(expectedDataDirectory);
            var actualFileSystemEntries = GetFilesWithAttributes(actualDataDirectory);
            var assert = ComponentResolver.Instance.Resolve<IClassicAssert>();

            var inExpectedOnly = expectedFileSystemEntries.Except(actualFileSystemEntries).ToList();
            var inActualOnly = actualFileSystemEntries.Except(expectedFileSystemEntries).ToList();

            var messageBuilder = new StringBuilder();

            var directoriesInExpectedOnly = GetDirectoryListString(inExpectedOnly);
            if (directoriesInExpectedOnly != "[]")
            {
                messageBuilder.Append($"  Directories in expected only: {directoriesInExpectedOnly}\r\n");
            }
            var directoriesInActualOnly = GetDirectoryListString(inActualOnly);
            if (directoriesInActualOnly != "[]")
            {
                messageBuilder.Append($"  Directories in actual only: {directoriesInActualOnly}\r\n");
            }

            var filesInExpectedOnly = GetFileListString(inExpectedOnly);
            if (filesInExpectedOnly != "[]")
            {
                messageBuilder.Append($"  Files in expected only: {filesInExpectedOnly}\r\n");
            }

            var filesInActualOnly = GetFileListString(inActualOnly);
            if (filesInActualOnly != "[]")
            {
                messageBuilder.Append($"  Files in actual only: {filesInActualOnly}\r\n");
            }

            // ReSharper disable once InvokeAsExtensionMethod
            var filesInBothDirs =
                Enumerable.Intersect(expectedFileSystemEntries, actualFileSystemEntries)
                    .Where(_ => !_.Attributes.HasFlag(FileAttributes.Directory))
                    .Select(_ => _.Path)
                    .ToList();
            var differ = new DiffPlex.DiffBuilder.InlineDiffBuilder(new Differ());
            var differingFiles = new List<string>();
            foreach (var filePath in filesInBothDirs)
            {
                var diffModel = differ.BuildDiffModel(
                    expectedDataDirectory.File.ReadAllText(filePath),
                    actualDataDirectory.File.ReadAllText(filePath));

                if (diffModel.Lines.Any(_ => _.Type != ChangeType.Unchanged))
                    differingFiles.Add(filePath);
            }
            if (differingFiles.Count > 0)
            {
                messageBuilder.Append($"  Differing files: [{string.Join(", ", differingFiles)}]\r\n");
            }

            var messagesString = messageBuilder.ToString();
            assert.IsTrue(messagesString == "",
                $"{assertion}\r\n" +
                $"  Expected test data directory: {expectedDataDirectory.Url}\r\n" +
                $"  Actual test data directory:   {actualDataDirectory.Url}\r\n" +
                messagesString);
        }

        private static string GetDirectoryListString(IEnumerable<FilePathAndAttributes> files)
        {
            var paths = files.Where(_ => _.Attributes.HasFlag(FileAttributes.Directory)).Select(_ => _.Path);
            return $"[{string.Join(", ", paths)}]";
        }

        private static string GetFileListString(IEnumerable<FilePathAndAttributes> files)
        {
            var paths = files.Where(_ => !_.Attributes.HasFlag(FileAttributes.Directory)).Select(_ => _.Path);
            return $"[{string.Join(", ", paths)}]";
        }

        private static List<FilePathAndAttributes> GetFilesWithAttributes(IFileSystemDirectory directory)
        {
            return directory.Directory.GetFileSystemEntries("", "*", SearchOption.AllDirectories)
                .Select(_ => _.Substring(directory.DirectoryPath.Length + 1)).Select(_ => new FilePathAndAttributes(_, directory.File.GetAttributes(_))).ToList();
        }

        private class FilePathAndAttributes
        {
            public string Path { get; }
            public FileAttributes Attributes { get; }

            public FilePathAndAttributes(string path, FileAttributes attributes)
            {
                Path = path;
                Attributes = attributes;
            }

            private bool Equals(FilePathAndAttributes other)
            {
                if (!string.Equals(Path, other.Path))
                    return false;
                if (Attributes.HasFlag(FileAttributes.Directory) && other.Attributes.HasFlag(FileAttributes.Directory))
                    return true;
                // ReSharper disable once ConvertIfStatementToReturnStatement
                if (Attributes.HasFlag(FileAttributes.Directory) || other.Attributes.HasFlag(FileAttributes.Directory))
                    return false;
                return true;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((FilePathAndAttributes) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((Path?.GetHashCode() ?? 0)*397) ^ (int) Attributes;
                }
            }
        }
    }
}