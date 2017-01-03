using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Testo.FileSystem;

namespace Testo.Tests.FileSystem
{
    public class InterfacesTests
    {
        [Test]
        public void SystemIoFileIsMapped()
        {
            AssertInterfaceIsMapped(typeof(ISystemIOFile), typeof(File));
        }

        [Test]
        public void SystemIoDirectoryIsMapped()
        {
            AssertInterfaceIsMapped(typeof(ISystemIODirectory), typeof(Directory));
        }

        private static void AssertInterfaceIsMapped(Type @interface, Type mappedStaticClass)
        {
            var iRootDirMethodInfos = @interface.GetMethods();
            var fileMethodInfos = mappedStaticClass.GetMethods(BindingFlags.Public | BindingFlags.Static);
            Assert.That(iRootDirMethodInfos,
                Is.EquivalentTo(fileMethodInfos).Using<MethodInfo, MethodInfo>((actual, expected) =>
                {
                    if (actual.Name != expected.Name)
                        return false;

                    if (actual.ReturnType != expected.ReturnType)
                        return false;

                    var actualParameters = actual.GetParameters().Select(_ => new {_.Name, _.ParameterType}).ToList();
                    var expectedParameters =
                        expected.GetParameters()
                            .Select(_ => new {Name = ConvertParameterName(_), _.ParameterType})
                            .ToList();
                    for (int i = 0; i < actualParameters.Count; i++)
                    {
                        var actualParamameter = actualParameters[i];
                        var expectedParameter = expectedParameters[i];
                        if (actualParamameter.Name != expectedParameter.Name ||
                            actualParamameter.ParameterType != expectedParameter.ParameterType)
                            return false;
                    }

                    return true;
                }));
        }

        private static string ConvertParameterName(ParameterInfo parameterInfo)
        {
            if (parameterInfo.ParameterType == typeof(string) && parameterInfo.Name == "path")
                return "subpath";
            if (parameterInfo.ParameterType == typeof(string) && parameterInfo.Name.EndsWith("Path"))
                return parameterInfo.Name.Substring(0, parameterInfo.Name.Length - 4) + "Subpath";
            return parameterInfo.Name;
        }

        // ReSharper disable once UnusedMember.Global
        // This test is used as code generation utility. Don't commit it with uncommented Test attribute.
        //[Test]
        public void GenerateFileSystemTypes()
        {
            GenerateInterfaceAndImplementation(typeof(File));
            GenerateInterfaceAndImplementation(typeof(Directory));
        }

        private static void GenerateInterfaceAndImplementation(Type staticTypeToWrap)
        {
            var fileStaticMethodInfos = staticTypeToWrap.GetMethods(BindingFlags.Public | BindingFlags.Static);

            var shortenedTypeFullName = staticTypeToWrap.FullName.Replace(".", "");
            var interfaceSrcPath = Path.Combine(TestContext.CurrentContext.TestDirectory,
                $"../src/Testo/FileSystem/I{shortenedTypeFullName}.cs");
            using (var writer = new StreamWriter(interfaceSrcPath))
            {
                writer.Write(
                    @"using System.Collections.Generic;

namespace Testo.FileSystem
{
    public interface I" + shortenedTypeFullName + @"
    {
");
                foreach (var methodInfo in fileStaticMethodInfos)
                {
                    RenderMethodDeclaration(writer, methodInfo);
                }
                writer.Write(
                    @"    }
}
");
            }

            var fileSystemRootDirSrcPath = Path.Combine(TestContext.CurrentContext.TestDirectory,
                $"../src/Testo/FileSystem/Impl/Default{shortenedTypeFullName}.cs");
            using (var writer = new StreamWriter(fileSystemRootDirSrcPath))
            {
                writer.Write(
                    @"using System.Collections.Generic;
using System.IO;

namespace Testo.FileSystem.Impl
{
    public class Default" + shortenedTypeFullName + @" : I" + shortenedTypeFullName + @"
    {
        public Default" + shortenedTypeFullName + @"(string rootDir)
        {
            RootDir = rootDir;
        }

        public string RootDir { get; }

");
                foreach (var methodInfo in fileStaticMethodInfos)
                {
                    RenderMethodImplementation(writer, methodInfo);
                }
                writer.Write(
                    @"    }
}
");
            }
        }

        private static void RenderMethodDeclaration(StreamWriter writer, MethodInfo methodInfo)
        {
            writer.Write(
                @"        " + RenderType(methodInfo.ReturnType) + @" " + RenderName(methodInfo) + @"(" +
                RenderParameters(methodInfo) + @");
");
        }

        private static void RenderMethodImplementation(StreamWriter writer, MethodInfo methodInfo)
        {
            var renderedArguments = methodInfo.GetParameters().Select(RenderArgument);
            writer.Write(
                @"        public " + RenderType(methodInfo.ReturnType) + @" " + RenderName(methodInfo) + @"(" +
                RenderParameters(methodInfo) + @")
        {
            " + RenderReturnKeyword(methodInfo) + methodInfo.DeclaringType.Name + @"." + RenderName(methodInfo) + @"(" +
                string.Join(", ", renderedArguments) + @");
        }
");
        }

        private static string RenderReturnKeyword(MethodInfo methodInfo)
        {
            return methodInfo.ReturnType == typeof(void) ? "" : "return ";
        }

        private static string RenderArgument(ParameterInfo parameterInfo)
        {
            if (parameterInfo.ParameterType == typeof(string) && parameterInfo.Name == "path")
                return "Path.Combine(RootDir, subpath)";
            if (parameterInfo.ParameterType == typeof(string) && parameterInfo.Name.EndsWith("Path"))
                return "Path.Combine(RootDir, " + parameterInfo.Name.Substring(0, parameterInfo.Name.Length - 4) +
                       "Subpath)";
            return parameterInfo.Name;
        }

        private static string RenderParameters(MethodInfo methodInfo)
        {
            var renderedParameters = methodInfo.GetParameters().Select(RenderParameter);
            return string.Join(", ", renderedParameters);
        }

        private static string RenderParameter(ParameterInfo parameterInfo)
        {
            if (parameterInfo.ParameterType == typeof(string) && parameterInfo.Name == "path")
                return "string subpath";
            if (parameterInfo.ParameterType == typeof(string) && parameterInfo.Name.EndsWith("Path"))
                return "string " + parameterInfo.Name.Substring(0, parameterInfo.Name.Length - 4) + "Subpath";
            return RenderType(parameterInfo.ParameterType) + " " + parameterInfo.Name;
        }

        private static string RenderName(MethodInfo methodInfo)
        {
            return methodInfo.Name;
        }

        private static readonly Dictionary<string, string> FullNameToCSharpBuiltIn = new Dictionary<string, string>
        {
            {"System.Boolean", "bool"},
            {"System.Byte", "byte"},
            {"System.SByte", "sbyte"},
            {"System.Char", "char"},
            {"System.Decimal", "decimal"},
            {"System.Double", "double"},
            {"System.Single", "float"},
            {"System.Int32", "int"},
            {"System.UInt32", "uint"},
            {"System.Int64", "long"},
            {"System.UInt64", "ulong"},
            {"System.Object", "object"},
            {"System.Int16", "short"},
            {"System.UInt16", "ushort"},
            {"System.String", "string"},
            {"System.Void", "void"}
        };

        private static string RenderType(Type type)
        {
            if (type.IsGenericType)
                return RenderGenericType(type);

            var fullName = type.FullName;

            string cSharpBuiltInName;
            if (FullNameToCSharpBuiltIn.TryGetValue(fullName, out cSharpBuiltInName))
                return cSharpBuiltInName;

            return fullName;
        }

        private static string RenderGenericType(Type type)
        {
            var renderedGenericTypeArguments = type.GenericTypeArguments.Select(RenderType);
            return type.Name.Substring(0, type.Name.Length - 2) + "<" + string.Join(", ", renderedGenericTypeArguments) +
                   ">";
        }
    }
}