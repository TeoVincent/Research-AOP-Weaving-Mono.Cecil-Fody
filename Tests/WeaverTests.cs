using System;
using System.IO;
using System.Reflection;
using Mono.Cecil;
using NUnit.Framework;
using TeoVincent.BasicFodyAddin.Fody;
using TeoVincent.Tests.WeaverCreators;

namespace TeoVincent.Tests
{
    [TestFixture]
    public class WeaverTests
    {
        Assembly assembly;
        string newAssemblyPath;
        string assemblyPath;

        public Assembly Assembly
        {
            set { assembly = value; }
            get { return assembly; }
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            var projectPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\AssemblyToProcess\AssemblyToProcess.csproj"));
            assemblyPath = Path.Combine(Path.GetDirectoryName(projectPath), @"bin\Debug\TeoVincent.AssemblyToProcess.dll");
#if (!DEBUG)
        assemblyPath = assemblyPath.Replace("Debug", "Release");
#endif

            newAssemblyPath = assemblyPath.Replace(".dll", "2.dll");
            File.Copy(assemblyPath, newAssemblyPath, true);

            var moduleDefinition = ModuleDefinition.ReadModule(newAssemblyPath);

            IWeaver weavingTask = CreateWeavers(moduleDefinition);
            weavingTask.Execute();
           
            moduleDefinition.Write(newAssemblyPath);

            assembly = Assembly.LoadFile(newAssemblyPath);
        }

#if(DEBUG)
        [Test]
        public void PeVerify()
        {
            Verifier.Verify(assemblyPath, newAssemblyPath);
        }

        private IWeaver CreateWeavers(ModuleDefinition moduleDefinition)
        {
            var weavers = new WeaverCollection();

            weavers.Add(new HellowWorldWeaverCreator(moduleDefinition).WeaverFactory());
            weavers.Add(new MethodCallsCounterWeaverCreator(moduleDefinition).WeaverFactory());

            return weavers;
        }
#endif
    }
}