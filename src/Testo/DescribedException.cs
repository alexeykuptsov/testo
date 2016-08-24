using System;
using EasyExceptions;

namespace Testo
{
  public class DescribedException : Exception
  {
    public DescribedException(Exception exception)
      : base(ExceptionDumpUtil.Dump(exception))
    {}
  }
}