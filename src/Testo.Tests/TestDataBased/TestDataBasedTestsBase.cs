using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testo.FileSystem.Impl;
using Testo.Tests.MsTest;

namespace Testo.Tests.TestDataBased
{
  public class TestDataBasedTestsBase
  {
    public TestContext TestContext { get; set; }

    protected ExpectedActualDirPair GetDirPair()
    {
      var testDataRootDir = GetTestDataDir();
      var expectedDirectoryPath = Path.Combine(testDataRootDir, "2exp");
      var expectedDataDir = new DefaultFileSystemDirectory(expectedDirectoryPath);
      expectedDataDir.CreateRecursivelyIfDoesNotExist();
      var actualDirectoryPath = Path.Combine(testDataRootDir, "3act");
      var actualDataDir = new DefaultFileSystemDirectory(actualDirectoryPath);
      actualDataDir.CreateRecursivelyIfDoesNotExist();
      var dirPair = new ExpectedActualDirPair(expectedDataDir, actualDataDir);
      return dirPair;
    }

    protected string GetTestDataDir()
    {
      var @namespace = GetType().Namespace;
      Assert.IsTrue(@namespace != null, "@namespace != null");
      var pathElements = new List<string>
      {
        TestContext.GetTestDirectory(),
        "..",
        "..",
        "testData"
      };
      var typeName = GetType().Name;
      pathElements.AddRange(
        TestContext.FullyQualifiedTestClassName.Replace(typeName,
            typeName.Substring(0, typeName.Length - "Tests".Length))
          .Split('.')
          .Where(_ => _ != "Testo" && _ != "Tests"));
      var testDataRootDir = Path.Combine(pathElements.Concat(new[] {TestContext.TestName}).ToArray());
      return testDataRootDir;
    }

    protected string GetExpectedMessage(ExpectedActualDirPair expectedActualDirPair)
    {
      var fieldName = TestContext.TestName + "ExpectedMessage";
      var fieldInfo = GetType()
        .GetField(
          fieldName,
          BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy);
      Assert.IsTrue(fieldInfo != null, "fieldInfo != null");
      Assert.IsTrue(fieldInfo.FieldType == typeof(string), "fieldInfo.FieldType == typeof(string)");
      var fieldValue = (string) fieldInfo.GetValue(this);
      return string.Format(fieldValue, expectedActualDirPair.Expected.Url, expectedActualDirPair.Actual.Url);
    }

    protected class ExpectedActualDirPair
    {
      public ExpectedActualDirPair(DefaultFileSystemDirectory expected, DefaultFileSystemDirectory actual)
      {
        Expected = expected;
        Actual = actual;
      }

      public DefaultFileSystemDirectory Expected { get; }
      public DefaultFileSystemDirectory Actual { get; }
    }
  }
}