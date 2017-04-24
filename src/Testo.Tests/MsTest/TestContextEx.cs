using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testo.Tests.MsTest
{
  public static class TestContextEx
  {
    public static string GetTestDirectory(this TestContext testContext)
    {
      foreach (var library in DependencyContext.Default.RuntimeLibraries)
      {
        var assembly = Assembly.Load(new AssemblyName(library.Name));
        var types = assembly.ExportedTypes;
        if (types.Any(_ => _.FullName == testContext.FullyQualifiedTestClassName))
        {
          return Directory.GetParent(assembly.Location).FullName;
        }
      }
      throw new InvalidOperationException("Failed to find the test assembly directory.");
    }
  }
}