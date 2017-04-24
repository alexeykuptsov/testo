namespace Testo.Extensibility
{
  public interface IComponentResolver
  {
    TComponent Resolve<TComponent>();
  }
}