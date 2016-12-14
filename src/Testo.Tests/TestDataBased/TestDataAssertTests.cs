using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Testo.FileSystem.Impl;
using Testo.TestDataBased;
// ReSharper disable UnusedMember.Local

namespace Testo.Tests.TestDataBased
{
    public class TestDataAssertTests
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

        private ExpectedActualDirPair GetDirPair()
        {
            var @namespace = GetType().Namespace;
            Assert.IsTrue(@namespace != null, "@namespace != null");
            var testContext = TestContext.CurrentContext;
            var pathElements = new List<string>
            {
                testContext.TestDirectory,
                "..",
                "testData"
            };
            var typeName = GetType().Name;
            pathElements.AddRange(
                testContext.Test.FullName.Replace(typeName, typeName.Substring(0, typeName.Length - "Tests".Length))
                    .Split('.')
                    .Where(_ => _ != "Testo" && _ != "Tests"));
            var testDataRootDir = Path.Combine(pathElements.ToArray());
            var expectedDirectoryPath = Path.Combine(testDataRootDir, "2exp");
            var expectedDataDir = new DefaultFileSystemDirectory(expectedDirectoryPath);
            expectedDataDir.CreateRecursivelyIfDoesNotExist();
            var actualDirectoryPath = Path.Combine(testDataRootDir, "3act");
            var actualDataDir = new DefaultFileSystemDirectory(actualDirectoryPath);
            actualDataDir.CreateRecursivelyIfDoesNotExist();
            var dirPair = new ExpectedActualDirPair(expectedDataDir, actualDataDir);
            return dirPair;
        }

        private string GetExpectedMessage(ExpectedActualDirPair expectedActualDirPair)
        {
            var fieldName = TestContext.CurrentContext.Test.Name + "ExpectedMessage";
            var fieldInfo = GetType().GetField(
                fieldName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            Assert.IsTrue(fieldInfo != null, "fieldInfo != null");
            Assert.IsTrue(fieldInfo.FieldType == typeof(string), "fieldInfo.FieldType == typeof(string)");
            var fieldValue = (string)fieldInfo.GetValue(this);
            return string.Format(fieldValue, expectedActualDirPair.Expected.Url, expectedActualDirPair.Actual.Url);
        }

        private class ExpectedActualDirPair
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