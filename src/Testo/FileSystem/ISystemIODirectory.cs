using System.Collections.Generic;

namespace Testo.FileSystem
{
    public interface ISystemIODirectory
    {
        System.IO.DirectoryInfo GetParent(string subpath);
        System.IO.DirectoryInfo CreateDirectory(string subpath);
        System.IO.DirectoryInfo CreateDirectory(string subpath, System.Security.AccessControl.DirectorySecurity directorySecurity);
        bool Exists(string subpath);
        void SetCreationTime(string subpath, System.DateTime creationTime);
        void SetCreationTimeUtc(string subpath, System.DateTime creationTimeUtc);
        System.DateTime GetCreationTime(string subpath);
        System.DateTime GetCreationTimeUtc(string subpath);
        void SetLastWriteTime(string subpath, System.DateTime lastWriteTime);
        void SetLastWriteTimeUtc(string subpath, System.DateTime lastWriteTimeUtc);
        System.DateTime GetLastWriteTime(string subpath);
        System.DateTime GetLastWriteTimeUtc(string subpath);
        void SetLastAccessTime(string subpath, System.DateTime lastAccessTime);
        void SetLastAccessTimeUtc(string subpath, System.DateTime lastAccessTimeUtc);
        System.DateTime GetLastAccessTime(string subpath);
        System.DateTime GetLastAccessTimeUtc(string subpath);
        System.Security.AccessControl.DirectorySecurity GetAccessControl(string subpath);
        System.Security.AccessControl.DirectorySecurity GetAccessControl(string subpath, System.Security.AccessControl.AccessControlSections includeSections);
        void SetAccessControl(string subpath, System.Security.AccessControl.DirectorySecurity directorySecurity);
        System.String[] GetFiles(string subpath);
        System.String[] GetFiles(string subpath, string searchPattern);
        System.String[] GetFiles(string subpath, string searchPattern, System.IO.SearchOption searchOption);
        System.String[] GetDirectories(string subpath);
        System.String[] GetDirectories(string subpath, string searchPattern);
        System.String[] GetDirectories(string subpath, string searchPattern, System.IO.SearchOption searchOption);
        System.String[] GetFileSystemEntries(string subpath);
        System.String[] GetFileSystemEntries(string subpath, string searchPattern);
        System.String[] GetFileSystemEntries(string subpath, string searchPattern, System.IO.SearchOption searchOption);
        IEnumerable<string> EnumerateDirectories(string subpath);
        IEnumerable<string> EnumerateDirectories(string subpath, string searchPattern);
        IEnumerable<string> EnumerateDirectories(string subpath, string searchPattern, System.IO.SearchOption searchOption);
        IEnumerable<string> EnumerateFiles(string subpath);
        IEnumerable<string> EnumerateFiles(string subpath, string searchPattern);
        IEnumerable<string> EnumerateFiles(string subpath, string searchPattern, System.IO.SearchOption searchOption);
        IEnumerable<string> EnumerateFileSystemEntries(string subpath);
        IEnumerable<string> EnumerateFileSystemEntries(string subpath, string searchPattern);
        IEnumerable<string> EnumerateFileSystemEntries(string subpath, string searchPattern, System.IO.SearchOption searchOption);
        System.String[] GetLogicalDrives();
        string GetDirectoryRoot(string subpath);
        string GetCurrentDirectory();
        void SetCurrentDirectory(string subpath);
        void Move(string sourceDirName, string destDirName);
        void Delete(string subpath);
        void Delete(string subpath, bool recursive);
    }
}
