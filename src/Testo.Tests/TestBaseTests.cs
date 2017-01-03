using NUnit.Framework;

namespace Testo.Tests
{
  public class TestBaseTests
  {
    [Test]
    public void Test01()
    {
      Assert.Throws<TestoException>(() =>
      {
        TestUtils.DoTest(() =>
        {
          Assert.IsTrue(false);
        });
      });
    }
  }
}