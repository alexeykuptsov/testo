using System;

namespace Testo
{
  public class TestsBase
  {
    public void DoTest(Action action)
    {
      try
      {
        action();
      }
      catch (Exception ex)
      {
        throw new DescribedException(ex);
      }
    }
  }
}