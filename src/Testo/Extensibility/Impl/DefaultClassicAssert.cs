using System;

namespace Testo.Extensibility.Impl
{
  public class DefaultClassicAssert : IClassicAssert
  {
    public void IsTrue(bool condition, string assertion)
    {
      if (!condition)
        throw new AssertionException("Assertion is violated." + Environment.NewLine + "Assertion: " + assertion);
    }

    public void Fail(string assertion)
    {
      throw new AssertionException("Assertion is violated." + Environment.NewLine + "Assertion:" + assertion);
    }
  }
}