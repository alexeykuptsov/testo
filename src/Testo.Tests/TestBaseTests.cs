using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testo.Tests
{
  [TestClass]
  public class TestBaseTests
  {
    [TestMethod]
    public void Test01()
    {
      Assert.ThrowsException<TestoException>(() => { TestUtils.DoTest(() => { Assert.IsTrue(false); }); });
    }
  }
}