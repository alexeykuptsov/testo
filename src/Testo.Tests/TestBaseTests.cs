using NUnit.Framework;

namespace Testo.Tests
{
  public class TestBaseTests
  {
    [Test]
    public void Test01()
    {
      var testsBase = new TestsBase();
      Assert.Throws<DescribedException>(() =>
      {
        testsBase.DoTest(() =>
        {
          Assert.IsTrue(false);
        });
      });
    }
  }
}