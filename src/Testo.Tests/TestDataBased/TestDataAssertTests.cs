using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testo.FileSystem.Impl;
using Testo.TestDataBased;
using Testo.Tests.MsTest;

// ReSharper disable UnusedMember.Local

namespace Testo.Tests.TestDataBased
{
  [TestClass]
  public class TestDataAssertTests : TestDataBasedTestsBase
  {
    private const string Test01ExpectedMessage =
      @"Assertion is violated.
Assertion: Directories are equal
  Expected test data directory: {0}
  Actual test data directory:   {1}
  Files in expected only: [empty.txt]
";

    [TestMethod]
    public void Test01()
    {
      DoTest();
    }

    private const string Test02ExpectedMessage =
      @"Assertion is violated.
Assertion: Directories are equal
  Expected test data directory: {0}
  Actual test data directory:   {1}
  Directories in expected only: [emptyDir]
";

    [TestMethod]
    public void Test02()
    {
      var directory = new DefaultFileSystemDirectory(
        Path.Combine(
          TestContext.GetTestDirectory(),
          "../../testData/TestDataBased/TestDataAssert/Test02/2exp/emptyDir"));
      directory.CreateRecursivelyIfDoesNotExist();
      DoTest();
    }

    private const string Test03ExpectedMessage =
      @"Assertion is violated.
Assertion: Directories are equal
  Expected test data directory: {0}
  Actual test data directory:   {1}
  Files in actual only: [empty.txt]
";

    [TestMethod]
    public void Test03()
    {
      DoTest();
    }

    private const string Test04ExpectedMessage =
      @"Assertion is violated.
Assertion: Directories are equal
  Expected test data directory: {0}
  Actual test data directory:   {1}
  Directories in actual only: [emptyDir]
";

    [TestMethod]
    public void Test04()
    {
      var directory = new DefaultFileSystemDirectory(
        Path.Combine(
          TestContext.GetTestDirectory(),
          "../../testData/TestDataBased/TestDataAssert/Test04/3act/emptyDir"));
      directory.CreateRecursivelyIfDoesNotExist();
      DoTest();
    }

    private const string Test05ExpectedMessage =
      @"Assertion is violated.
Assertion: Directories are equal
  Expected test data directory: {0}
  Actual test data directory:   {1}
  Differing files: [foo.txt]
";

    [TestMethod]
    public void Test05()
    {
      DoTest();
    }

    [TestMethod]
    public void Test06()
    {
      TestUtils.DoTest(() =>
      {
        var dirPair = GetDirPair();
        TestDataAssert.DirectoriesAreEqual(dirPair.Expected, dirPair.Actual);
      });
    }

    private void DoTest()
    {
      TestUtils.DoTest(() =>
      {
        var dirPair = GetDirPair();

        try
        {
          TestDataAssert.DirectoriesAreEqual(dirPair.Expected, dirPair.Actual);
        }
        catch (AssertionException ex)
        {
          Assert.AreEqual(GetExpectedMessage(dirPair), ex.Message, "AreEqual(ex.Message, Test01ExpectedMessage)");
          return;
        }

        Assert.Fail("Expected exception wasn't thrown.");
      });
    }
  }
}