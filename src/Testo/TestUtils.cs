using System;

namespace Testo
{
  public static class TestUtils
  {
    public static void DoTest(Action action)
    {
      try
      {
        action();
      }
      catch (Exception ex)
      {
        throw new TestoException(ex);
      }
    }
  }
}