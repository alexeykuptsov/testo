using System;
using EasyExceptions;

namespace Testo
{
  public class TestoException : Exception
  {
    public TestoException(Exception exception)
      : base(ExceptionDumpUtil.Dump(exception))
    {
    }
  }
}