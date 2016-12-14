using System.IO;

namespace Testo.FileSystem.Impl
{
    public class DefaultFileSystemDirectory : IFileSystemDirectory
    {
        public string DirectoryPath { get; }

        public DefaultFileSystemDirectory(string directoryPath)
        {
            DirectoryPath = Path.GetFullPath(directoryPath);
            File = new DefaultSystemIOFile(DirectoryPath);
            Directory = new DefaultSystemIODirectory(DirectoryPath);
        }

        public ISystemIOFile File { get; }

        public ISystemIODirectory Directory { get; }

        public string Url => "file://" + DirectoryPath;

        public void CreateRecursivelyIfDoesNotExist()
        {
            var pathParts = Path.GetFullPath(DirectoryPath).Split(Path.PathSeparator);

            for (var i = 0; i < pathParts.Length; i++)
            {
                if (i > 0)
                    pathParts[i] = Path.Combine(pathParts[i - 1], pathParts[i]);

                if (!Directory.Exists(pathParts[i]))
                    Directory.CreateDirectory(pathParts[i]);
            }
        }
    }
}