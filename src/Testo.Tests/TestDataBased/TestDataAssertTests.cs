﻿using System.IO;
using NUnit.Framework;
using Testo.FileSystem.Impl;
using Testo.TestDataBased;
// ReSharper disable UnusedMember.Local

namespace Testo.Tests.TestDataBased
{
    public class TestDataAssertTests : TestDataBasedTestsBase
    {
        private const string Test01ExpectedMessage =
@"Assertion is violated.
Assertion: Directories are equal
  Expected test data directory: {0}
  Actual test data directory:   {1}
  Files in expected only: [empty.txt]
";

        [Test]
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

        [Test]
        public void Test02()
        {
            var directory = new DefaultFileSystemDirectory(
                Path.Combine(
                    TestContext.CurrentContext.TestDirectory,
                    "../testData/TestDataBased/TestDataAssert/Test02/2exp/emptyDir"));
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

        [Test]
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

        [Test]
        public void Test04()
        {
            var directory = new DefaultFileSystemDirectory(
                Path.Combine(
                    TestContext.CurrentContext.TestDirectory,
                    "../testData/TestDataBased/TestDataAssert/Test04/3act/emptyDir"));
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

        [Test]
        public void Test05()
        {
            DoTest();
        }

        [Test]
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