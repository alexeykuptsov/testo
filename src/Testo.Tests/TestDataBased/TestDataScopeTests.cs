using System;
using NUnit.Framework;
using Testo.FileSystem;
using Testo.FileSystem.Impl;
using Testo.TestDataBased;
// ReSharper disable UnusedMember.Local

namespace Testo.Tests.TestDataBased
{
    public class TestDataScopeTests : TestDataBasedTestsBase
    {
        private const string Test01ExpectedMessage =
@"Assertion is violated.
Assertion: Directories are equal
  Expected test data directory: {0}
  Actual test data directory:   {1}
  Files in actual only: [foo.txt]
";

        [Test]
        public void Test01()
        {
            DoTest(actualDir =>
            {
                actualDir.File.WriteAllText("foo.txt", "bar");
            });
        }

        private const string Test02ExpectedMessage =
@"Assertion is violated.
Assertion: Directories are equal
  Expected test data directory: {0}
  Actual test data directory:   {1}
  Files in expected only: [bar.txt]
  Files in actual only: [foo.txt]
";

        [Test]
        public void Test02()
        {
            DoTest(actualDir => {});
        }

        private void DoTest(Action<IFileSystemDirectory> action)
        {
            TestUtils.DoTest(() =>
            {
                var testDataDir = new DefaultFileSystemDirectory(GetTestDataDir());
                var dirPair = GetDirPair();

                try
                {
                    TestDataScope.Using(testDataDir, action);
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