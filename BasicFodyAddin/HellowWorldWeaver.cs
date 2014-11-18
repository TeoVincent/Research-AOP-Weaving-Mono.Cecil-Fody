using System;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace TeoVincent.BasicFodyAddin.Fody
{
    public class HellowWorldWeaver : IWeaver
    {
        private readonly ModuleDefinition moduleDefinition;

        public HellowWorldWeaver(ModuleDefinition moduleDefinition)
        {
            this.moduleDefinition = moduleDefinition;
        }

        public void Execute()
        {
            var typeSystem = moduleDefinition.TypeSystem;
            var newType = new TypeDefinition(null, "Hello", TypeAttributes.Public, typeSystem.Object);

            AddConstructor(newType);
            AddHelloWorld(newType);
            moduleDefinition.Types.Add(newType);
        }

        private void AddConstructor(TypeDefinition newType)
        {
            var typeSystem = moduleDefinition.TypeSystem;
            var method = new MethodDefinition(".ctor", 
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName, typeSystem.Void);

            var objectConstructor = moduleDefinition.Import(typeSystem.Object.Resolve().GetConstructors().First());
            var processor = method.Body.GetILProcessor();
            processor.Emit(OpCodes.Ldarg_0);
            processor.Emit(OpCodes.Call, objectConstructor);
            processor.Emit(OpCodes.Ret);
            newType.Methods.Add(method);
        }

        private void AddHelloWorld(TypeDefinition newType)
        {
            var typeSystem = moduleDefinition.TypeSystem;
            var method = new MethodDefinition("World", MethodAttributes.Public, typeSystem.String);
            var processor = method.Body.GetILProcessor();
            processor.Emit(OpCodes.Ldstr, "Hello World");
            processor.Emit(OpCodes.Ret);
            newType.Methods.Add(method);
        }
    }
}
