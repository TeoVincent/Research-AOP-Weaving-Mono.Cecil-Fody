using System;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace TeoVincent.BasicFodyAddin.Fody
{
    public class HellowWorldWeaver
    {
        public Action<string> LogInfo { get; set; }
        public ModuleDefinition ModuleDefinition { get; set; }

        private TypeSystem typeSystem;

        public HellowWorldWeaver()
        {
            LogInfo = m => { };
        }

        public void Execute()
        {
            typeSystem = ModuleDefinition.TypeSystem;
            var newType = new TypeDefinition(null, "Hello", TypeAttributes.Public, typeSystem.Object);

            AddConstructor(newType);
            AddHelloWorld(newType);
            ModuleDefinition.Types.Add(newType);
            LogInfo("Added type 'Hello' with method 'World'.");

            AddMethodCallsCounter();
            LogInfo("Added aspect 'MethodCallsCounter'");
        }

        private void AddConstructor(TypeDefinition newType)
        {
            var method = new MethodDefinition(".ctor", 
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName, typeSystem.Void);
            
            var objectConstructor = ModuleDefinition.Import(typeSystem.Object.Resolve().GetConstructors().First());
            var processor = method.Body.GetILProcessor();
            processor.Emit(OpCodes.Ldarg_0);
            processor.Emit(OpCodes.Call, objectConstructor);
            processor.Emit(OpCodes.Ret);
            newType.Methods.Add(method);
        }

        private void AddHelloWorld(TypeDefinition newType)
        {
            var method = new MethodDefinition("World", MethodAttributes.Public, typeSystem.String);
            var processor = method.Body.GetILProcessor();
            processor.Emit(OpCodes.Ldstr, "Hello World");
            processor.Emit(OpCodes.Ret);
            newType.Methods.Add(method);
        }

        private void AddMethodCallsCounter()
        {
            var attributeFinder = new AttributeFinder();
            var methodCallsCounterWeaver = new MethodCallsCounterWeaver(attributeFinder, ModuleDefinition);
            methodCallsCounterWeaver.AddMethodCallsCounter();
        }
    }
}
