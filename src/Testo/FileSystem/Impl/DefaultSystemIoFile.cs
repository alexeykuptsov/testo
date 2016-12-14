using System.Collections.Generic;
using System.IO;

namespace Testo.FileSystem.Impl
{
    public class DefaultSystemIOFile : ISystemIOFile
    {
        public DefaultSystemIOFile(string rootDir)
        {
            RootDir = rootDir;
        }

        public string RootDir { get; }

        public System.IO.StreamReader OpenText(string subpath)
        {
            return File.OpenText(Path.Combine(RootDir, subpath));
        }
        public System.IO.StreamWriter CreateText(string subpath)
        {
            return File.CreateText(Path.Combine(RootDir, subpath));
        }
        public System.IO.StreamWriter AppendText(string subpath)
        {
            return File.AppendText(Path.Combine(RootDir, subpath));
        }
        public void Copy(string sourceFileName, string destFileName)
        {
            File.Copy(sourceFileName, destFileName);
        }
        public void Copy(string sourceFileName, string destFileName, bool overwrite)
        {
            File.Copy(sourceFileName, destFileName, overwrite);
        }
        public System.IO.FileStream Create(string subpath)
        {
            return File.Create(Path.Combine(RootDir, subpath));
        }
        public System.IO.FileStream Create(string subpath, int bufferSize)
        {
            return File.Create(Path.Combine(RootDir, subpath), bufferSize);
        }
        public System.IO.FileStream Create(string subpath, int bufferSize, System.IO.FileOptions options)
        {
            return File.Create(Path.Combine(RootDir, subpath), bufferSize, options);
        }
        public System.IO.FileStream Create(string subpath, int bufferSize, System.IO.FileOptions options, System.Security.AccessControl.FileSecurity fileSecurity)
        {
            return File.Create(Path.Combine(RootDir, subpath), bufferSize, options, fileSecurity);
        }
        public void Delete(string subpath)
        {
            File.Delete(Path.Combine(RootDir, subpath));
        }
        public void Decrypt(string subpath)
        {
            File.Decrypt(Path.Combine(RootDir, subpath));
        }
        public void Encrypt(string subpath)
        {
            File.Encrypt(Path.Combine(RootDir, subpath));
        }
        public bool Exists(string subpath)
        {
            return File.Exists(Path.Combine(RootDir, subpath));
        }
        public System.IO.FileStream Open(string subpath, System.IO.FileMode mode)
        {
            return File.Open(Path.Combine(RootDir, subpath), mode);
        }
        public System.IO.FileStream Open(string subpath, System.IO.FileMode mode, System.IO.FileAccess access)
        {
            return File.Open(Path.Combine(RootDir, subpath), mode, access);
        }
        public System.IO.FileStream Open(string subpath, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share)
        {
            return File.Open(Path.Combine(RootDir, subpath), mode, access, share);
        }
        public void SetCreationTime(string subpath, System.DateTime creationTime)
        {
            File.SetCreationTime(Path.Combine(RootDir, subpath), creationTime);
        }
        public void SetCreationTimeUtc(string subpath, System.DateTime creationTimeUtc)
        {
            File.SetCreationTimeUtc(Path.Combine(RootDir, subpath), creationTimeUtc);
        }
        public System.DateTime GetCreationTime(string subpath)
        {
            return File.GetCreationTime(Path.Combine(RootDir, subpath));
        }
        public System.DateTime GetCreationTimeUtc(string subpath)
        {
            return File.GetCreationTimeUtc(Path.Combine(RootDir, subpath));
        }
        public void SetLastAccessTime(string subpath, System.DateTime lastAccessTime)
        {
            File.SetLastAccessTime(Path.Combine(RootDir, subpath), lastAccessTime);
        }
        public void SetLastAccessTimeUtc(string subpath, System.DateTime lastAccessTimeUtc)
        {
            File.SetLastAccessTimeUtc(Path.Combine(RootDir, subpath), lastAccessTimeUtc);
        }
        public System.DateTime GetLastAccessTime(string subpath)
        {
            return File.GetLastAccessTime(Path.Combine(RootDir, subpath));
        }
        public System.DateTime GetLastAccessTimeUtc(string subpath)
        {
            return File.GetLastAccessTimeUtc(Path.Combine(RootDir, subpath));
        }
        public void SetLastWriteTime(string subpath, System.DateTime lastWriteTime)
        {
            File.SetLastWriteTime(Path.Combine(RootDir, subpath), lastWriteTime);
        }
        public void SetLastWriteTimeUtc(string subpath, System.DateTime lastWriteTimeUtc)
        {
            File.SetLastWriteTimeUtc(Path.Combine(RootDir, subpath), lastWriteTimeUtc);
        }
        public System.DateTime GetLastWriteTime(string subpath)
        {
            return File.GetLastWriteTime(Path.Combine(RootDir, subpath));
        }
        public System.DateTime GetLastWriteTimeUtc(string subpath)
        {
            return File.GetLastWriteTimeUtc(Path.Combine(RootDir, subpath));
        }
        public System.IO.FileAttributes GetAttributes(string subpath)
        {
            return File.GetAttributes(Path.Combine(RootDir, subpath));
        }
        public void SetAttributes(string subpath, System.IO.FileAttributes fileAttributes)
        {
            File.SetAttributes(Path.Combine(RootDir, subpath), fileAttributes);
        }
        public System.Security.AccessControl.FileSecurity GetAccessControl(string subpath)
        {
            return File.GetAccessControl(Path.Combine(RootDir, subpath));
        }
        public System.Security.AccessControl.FileSecurity GetAccessControl(string subpath, System.Security.AccessControl.AccessControlSections includeSections)
        {
            return File.GetAccessControl(Path.Combine(RootDir, subpath), includeSections);
        }
        public void SetAccessControl(string subpath, System.Security.AccessControl.FileSecurity fileSecurity)
        {
            File.SetAccessControl(Path.Combine(RootDir, subpath), fileSecurity);
        }
        public System.IO.FileStream OpenRead(string subpath)
        {
            return File.OpenRead(Path.Combine(RootDir, subpath));
        }
        public System.IO.FileStream OpenWrite(string subpath)
        {
            return File.OpenWrite(Path.Combine(RootDir, subpath));
        }
        public string ReadAllText(string subpath)
        {
            return File.ReadAllText(Path.Combine(RootDir, subpath));
        }
        public string ReadAllText(string subpath, System.Text.Encoding encoding)
        {
            return File.ReadAllText(Path.Combine(RootDir, subpath), encoding);
        }
        public void WriteAllText(string subpath, string contents)
        {
            File.WriteAllText(Path.Combine(RootDir, subpath), contents);
        }
        public void WriteAllText(string subpath, string contents, System.Text.Encoding encoding)
        {
            File.WriteAllText(Path.Combine(RootDir, subpath), contents, encoding);
        }
        public System.Byte[] ReadAllBytes(string subpath)
        {
            return File.ReadAllBytes(Path.Combine(RootDir, subpath));
        }
        public void WriteAllBytes(string subpath, System.Byte[] bytes)
        {
            File.WriteAllBytes(Path.Combine(RootDir, subpath), bytes);
        }
        public System.String[] ReadAllLines(string subpath)
        {
            return File.ReadAllLines(Path.Combine(RootDir, subpath));
        }
        public System.String[] ReadAllLines(string subpath, System.Text.Encoding encoding)
        {
            return File.ReadAllLines(Path.Combine(RootDir, subpath), encoding);
        }
        public IEnumerable<string> ReadLines(string subpath)
        {
            return File.ReadLines(Path.Combine(RootDir, subpath));
        }
        public IEnumerable<string> ReadLines(string subpath, System.Text.Encoding encoding)
        {
            return File.ReadLines(Path.Combine(RootDir, subpath), encoding);
        }
        public void WriteAllLines(string subpath, System.String[] contents)
        {
            File.WriteAllLines(Path.Combine(RootDir, subpath), contents);
        }
        public void WriteAllLines(string subpath, System.String[] contents, System.Text.Encoding encoding)
        {
            File.WriteAllLines(Path.Combine(RootDir, subpath), contents, encoding);
        }
        public void WriteAllLines(string subpath, IEnumerable<string> contents)
        {
            File.WriteAllLines(Path.Combine(RootDir, subpath), contents);
        }
        public void WriteAllLines(string subpath, IEnumerable<string> contents, System.Text.Encoding encoding)
        {
            File.WriteAllLines(Path.Combine(RootDir, subpath), contents, encoding);
        }
        public void AppendAllText(string subpath, string contents)
        {
            File.AppendAllText(Path.Combine(RootDir, subpath), contents);
        }
        public void AppendAllText(string subpath, string contents, System.Text.Encoding encoding)
        {
            File.AppendAllText(Path.Combine(RootDir, subpath), contents, encoding);
        }
        public void AppendAllLines(string subpath, IEnumerable<string> contents)
        {
            File.AppendAllLines(Path.Combine(RootDir, subpath), contents);
        }
        public void AppendAllLines(string subpath, IEnumerable<string> contents, System.Text.Encoding encoding)
        {
            File.AppendAllLines(Path.Combine(RootDir, subpath), contents, encoding);
        }
        public void Move(string sourceFileName, string destFileName)
        {
            File.Move(sourceFileName, destFileName);
        }
        public void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName)
        {
            File.Replace(sourceFileName, destinationFileName, destinationBackupFileName);
        }
        public void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors)
        {
            File.Replace(sourceFileName, destinationFileName, destinationBackupFileName, ignoreMetadataErrors);
        }
    }
}
