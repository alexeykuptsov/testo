using System.Collections.Generic;

namespace Testo.FileSystem
{
  public interface ISystemIOFile
  {
    System.IO.StreamReader OpenText(string subpath);
    System.IO.StreamWriter CreateText(string subpath);
    System.IO.StreamWriter AppendText(string subpath);
    void Copy(string sourceFileName, string destFileName);
    void Copy(string sourceFileName, string destFileName, bool overwrite);
    System.IO.FileStream Create(string subpath);
    System.IO.FileStream Create(string subpath, int bufferSize);
    System.IO.FileStream Create(string subpath, int bufferSize, System.IO.FileOptions options);
    void Delete(string subpath);
    bool Exists(string subpath);
    System.IO.FileStream Open(string subpath, System.IO.FileMode mode);
    System.IO.FileStream Open(string subpath, System.IO.FileMode mode, System.IO.FileAccess access);

    System.IO.FileStream Open(string subpath, System.IO.FileMode mode, System.IO.FileAccess access,
      System.IO.FileShare share);

    void SetCreationTime(string subpath, System.DateTime creationTime);
    void SetCreationTimeUtc(string subpath, System.DateTime creationTimeUtc);
    System.DateTime GetCreationTime(string subpath);
    System.DateTime GetCreationTimeUtc(string subpath);
    void SetLastAccessTime(string subpath, System.DateTime lastAccessTime);
    void SetLastAccessTimeUtc(string subpath, System.DateTime lastAccessTimeUtc);
    System.DateTime GetLastAccessTime(string subpath);
    System.DateTime GetLastAccessTimeUtc(string subpath);
    void SetLastWriteTime(string subpath, System.DateTime lastWriteTime);
    void SetLastWriteTimeUtc(string subpath, System.DateTime lastWriteTimeUtc);
    System.DateTime GetLastWriteTime(string subpath);
    System.DateTime GetLastWriteTimeUtc(string subpath);
    System.IO.FileAttributes GetAttributes(string subpath);
    void SetAttributes(string subpath, System.IO.FileAttributes fileAttributes);
    System.IO.FileStream OpenRead(string subpath);
    System.IO.FileStream OpenWrite(string subpath);
    string ReadAllText(string subpath);
    string ReadAllText(string subpath, System.Text.Encoding encoding);
    void WriteAllText(string subpath, string contents);
    void WriteAllText(string subpath, string contents, System.Text.Encoding encoding);
    System.Byte[] ReadAllBytes(string subpath);
    void WriteAllBytes(string subpath, System.Byte[] bytes);
    System.String[] ReadAllLines(string subpath);
    System.String[] ReadAllLines(string subpath, System.Text.Encoding encoding);
    IEnumerable<string> ReadLines(string subpath);
    IEnumerable<string> ReadLines(string subpath, System.Text.Encoding encoding);
    void WriteAllLines(string subpath, System.String[] contents);
    void WriteAllLines(string subpath, System.String[] contents, System.Text.Encoding encoding);
    void WriteAllLines(string subpath, IEnumerable<string> contents);
    void WriteAllLines(string subpath, IEnumerable<string> contents, System.Text.Encoding encoding);
    void AppendAllText(string subpath, string contents);
    void AppendAllText(string subpath, string contents, System.Text.Encoding encoding);
    void AppendAllLines(string subpath, IEnumerable<string> contents);
    void AppendAllLines(string subpath, IEnumerable<string> contents, System.Text.Encoding encoding);
    void Move(string sourceFileName, string destFileName);
  }
}