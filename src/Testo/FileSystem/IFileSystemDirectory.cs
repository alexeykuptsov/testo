namespace Testo.FileSystem
{
    public interface IFileSystemDirectory
    {
        ISystemIOFile File { get; }
        ISystemIODirectory Directory { get; }
        string Url { get; }
        string DirectoryPath { get; }
    }
}