using System;

namespace Testo.Extensibility.Impl
{
  public class DefaultComponentResolver : IComponentResolver
  {
    public TComponent Resolve<TComponent>()
    {
      if (typeof(TComponent) == typeof(IClassicAssert))
        return (TComponent) DefaultClassicAssertLazy.Value;

      throw new NotSupportedException(
        $"DefaultComponentResolver doesn't support type {typeof(TComponent).FullName}");
    }

    public Lazy<IClassicAssert> DefaultClassicAssertLazy { get; } =
      new Lazy<IClassicAssert>(() => new DefaultClassicAssert());
  }
}