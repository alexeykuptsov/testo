using System.Collections.Generic;
using System.IO;

namespace Testo.FileSystem.Impl
{
  public class DefaultSystemIODirectory : ISystemIODirectory
  {
    public DefaultSystemIODirectory(string rootDir)
    {
      RootDir = rootDir;
    }

    public string RootDir { get; }

    public System.IO.DirectoryInfo GetParent(string subpath)
    {
      return Directory.GetParent(Path.Combine(RootDir, subpath));
    }

    public System.IO.DirectoryInfo CreateDirectory(string subpath)
    {
      return Directory.CreateDirectory(Path.Combine(RootDir, subpath));
    }

    public bool Exists(string subpath)
    {
      return Directory.Exists(Path.Combine(RootDir, subpath));
    }

    public void SetCreationTime(string subpath, System.DateTime creationTime)
    {
      Directory.SetCreationTime(Path.Combine(RootDir, subpath), creationTime);
    }

    public void SetCreationTimeUtc(string subpath, System.DateTime creationTimeUtc)
    {
      Directory.SetCreationTimeUtc(Path.Combine(RootDir, subpath), creationTimeUtc);
    }

    public System.DateTime GetCreationTime(string subpath)
    {
      return Directory.GetCreationTime(Path.Combine(RootDir, subpath));
    }

    public System.DateTime GetCreationTimeUtc(string subpath)
    {
      return Directory.GetCreationTimeUtc(Path.Combine(RootDir, subpath));
    }

    public void SetLastWriteTime(string subpath, System.DateTime lastWriteTime)
    {
      Directory.SetLastWriteTime(Path.Combine(RootDir, subpath), lastWriteTime);
    }

    public void SetLastWriteTimeUtc(string subpath, System.DateTime lastWriteTimeUtc)
    {
      Directory.SetLastWriteTimeUtc(Path.Combine(RootDir, subpath), lastWriteTimeUtc);
    }

    public System.DateTime GetLastWriteTime(string subpath)
    {
      return Directory.GetLastWriteTime(Path.Combine(RootDir, subpath));
    }

    public System.DateTime GetLastWriteTimeUtc(string subpath)
    {
      return Directory.GetLastWriteTimeUtc(Path.Combine(RootDir, subpath));
    }

    public void SetLastAccessTime(string subpath, System.DateTime lastAccessTime)
    {
      Directory.SetLastAccessTime(Path.Combine(RootDir, subpath), lastAccessTime);
    }

    public void SetLastAccessTimeUtc(string subpath, System.DateTime lastAccessTimeUtc)
    {
      Directory.SetLastAccessTimeUtc(Path.Combine(RootDir, subpath), lastAccessTimeUtc);
    }

    public System.DateTime GetLastAccessTime(string subpath)
    {
      return Directory.GetLastAccessTime(Path.Combine(RootDir, subpath));
    }

    public System.DateTime GetLastAccessTimeUtc(string subpath)
    {
      return Directory.GetLastAccessTimeUtc(Path.Combine(RootDir, subpath));
    }

    public System.String[] GetFiles(string subpath)
    {
      return Directory.GetFiles(Path.Combine(RootDir, subpath));
    }

    public System.String[] GetFiles(string subpath, string searchPattern)
    {
      return Directory.GetFiles(Path.Combine(RootDir, subpath), searchPattern);
    }

    public System.String[] GetFiles(string subpath, string searchPattern, System.IO.SearchOption searchOption)
    {
      return Directory.GetFiles(Path.Combine(RootDir, subpath), searchPattern, searchOption);
    }

    public System.String[] GetDirectories(string subpath)
    {
      return Directory.GetDirectories(Path.Combine(RootDir, subpath));
    }

    public System.String[] GetDirectories(string subpath, string searchPattern)
    {
      return Directory.GetDirectories(Path.Combine(RootDir, subpath), searchPattern);
    }

    public System.String[] GetDirectories(string subpath, string searchPattern, System.IO.SearchOption searchOption)
    {
      return Directory.GetDirectories(Path.Combine(RootDir, subpath), searchPattern, searchOption);
    }

    public System.String[] GetFileSystemEntries(string subpath)
    {
      return Directory.GetFileSystemEntries(Path.Combine(RootDir, subpath));
    }

    public System.String[] GetFileSystemEntries(string subpath, string searchPattern)
    {
      return Directory.GetFileSystemEntries(Path.Combine(RootDir, subpath), searchPattern);
    }

    public System.String[] GetFileSystemEntries(string subpath, string searchPattern,
      System.IO.SearchOption searchOption)
    {
      return Directory.GetFileSystemEntries(Path.Combine(RootDir, subpath), searchPattern, searchOption);
    }

    public IEnumerable<string> EnumerateDirectories(string subpath)
    {
      return Directory.EnumerateDirectories(Path.Combine(RootDir, subpath));
    }

    public IEnumerable<string> EnumerateDirectories(string subpath, string searchPattern)
    {
      return Directory.EnumerateDirectories(Path.Combine(RootDir, subpath), searchPattern);
    }

    public IEnumerable<string> EnumerateDirectories(string subpath, string searchPattern,
      System.IO.SearchOption searchOption)
    {
      return Directory.EnumerateDirectories(Path.Combine(RootDir, subpath), searchPattern, searchOption);
    }

    public IEnumerable<string> EnumerateFiles(string subpath)
    {
      return Directory.EnumerateFiles(Path.Combine(RootDir, subpath));
    }

    public IEnumerable<string> EnumerateFiles(string subpath, string searchPattern)
    {
      return Directory.EnumerateFiles(Path.Combine(RootDir, subpath), searchPattern);
    }

    public IEnumerable<string> EnumerateFiles(string subpath, string searchPattern, System.IO.SearchOption searchOption)
    {
      return Directory.EnumerateFiles(Path.Combine(RootDir, subpath), searchPattern, searchOption);
    }

    public IEnumerable<string> EnumerateFileSystemEntries(string subpath)
    {
      return Directory.EnumerateFileSystemEntries(Path.Combine(RootDir, subpath));
    }

    public IEnumerable<string> EnumerateFileSystemEntries(string subpath, string searchPattern)
    {
      return Directory.EnumerateFileSystemEntries(Path.Combine(RootDir, subpath), searchPattern);
    }

    public IEnumerable<string> EnumerateFileSystemEntries(string subpath, string searchPattern,
      System.IO.SearchOption searchOption)
    {
      return Directory.EnumerateFileSystemEntries(Path.Combine(RootDir, subpath), searchPattern, searchOption);
    }

    public string GetDirectoryRoot(string subpath)
    {
      return Directory.GetDirectoryRoot(Path.Combine(RootDir, subpath));
    }

    public string GetCurrentDirectory()
    {
      return Directory.GetCurrentDirectory();
    }

    public void SetCurrentDirectory(string subpath)
    {
      Directory.SetCurrentDirectory(Path.Combine(RootDir, subpath));
    }

    public void Move(string sourceDirName, string destDirName)
    {
      Directory.Move(sourceDirName, destDirName);
    }

    public void Delete(string subpath)
    {
      Directory.Delete(Path.Combine(RootDir, subpath));
    }

    public void Delete(string subpath, bool recursive)
    {
      Directory.Delete(Path.Combine(RootDir, subpath), recursive);
    }
  }
}