using System;
using System.IO;
using Testo.FileSystem;
using Testo.FileSystem.Impl;

namespace Testo.TestDataBased
{
  public static class TestDataScope
  {
    public static void Using(IFileSystemDirectory testDataDir, Action<IFileSystemDirectory> actionOnActualDirectory)
    {
      var srcDir = new DefaultFileSystemDirectory(Path.Combine(testDataDir.DirectoryPath, "1src"));
      var expDir = new DefaultFileSystemDirectory(Path.Combine(testDataDir.DirectoryPath, "2exp"));
      var actDir = new DefaultFileSystemDirectory(Path.Combine(testDataDir.DirectoryPath, "3act"));
      actDir.Directory.Delete(".", true);
      if (srcDir.Directory.Exists("."))
        DirectoryCopy(srcDir.DirectoryPath, actDir.DirectoryPath, true);
      else
        actDir.CreateRecursivelyIfDoesNotExist();
      actionOnActualDirectory(actDir);
      TestDataAssert.DirectoriesAreEqual(expDir, actDir);
      actDir.Directory.Delete(".", true);
    }

    private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
      // Get the subdirectories for the specified directory.
      DirectoryInfo dir = new DirectoryInfo(sourceDirName);

      if (!dir.Exists)
      {
        throw new DirectoryNotFoundException(
          "Source directory does not exist or could not be found: "
          + sourceDirName);
      }

      DirectoryInfo[] dirs = dir.GetDirectories();
      // If the destination directory doesn't exist, create it.
      if (!Directory.Exists(destDirName))
      {
        Directory.CreateDirectory(destDirName);
      }

      // Get the files in the directory and copy them to the new location.
      FileInfo[] files = dir.GetFiles();
      foreach (FileInfo file in files)
      {
        string temppath = Path.Combine(destDirName, file.Name);
        file.CopyTo(temppath, false);
      }

      // If copying subdirectories, copy them and their contents to new location.
      if (copySubDirs)
      {
        foreach (DirectoryInfo subdir in dirs)
        {
          string temppath = Path.Combine(destDirName, subdir.Name);
          DirectoryCopy(subdir.FullName, temppath, copySubDirs);
        }
      }
    }
  }
}