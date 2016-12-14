using Testo.Extensibility.Impl;

namespace Testo.Extensibility
{
    public static class ComponentResolver
    {
        public static IComponentResolver Instance { get; set; } = new DefaultComponentResolver();
    }
}