using Mono.Cecil;
using Mono.Cecil.Cil;

namespace TeoVincent.BasicFodyAddin.Fody
{
    public class MethodCallsCounterWeaver
    {
        private readonly IAttributeFinder atributeFinder;
        private readonly ModuleDefinition moduleDefinition;

        private const string COUNT_CALLS_THEM_ATTRIBUTE_NAME = "TeoVincent.AssemblyToProcess.MethodCallsCouting.CountCallsThemAttribute";
        private const string PROPERTY_POSTFIX = "CallsCount";

        public MethodCallsCounterWeaver(IAttributeFinder atributeFinder, ModuleDefinition moduleDefinition)
        {
            this.atributeFinder = atributeFinder;
            this.moduleDefinition = moduleDefinition;
        }

        public void AddMethodCallsCounter()
        {
            var mtCollection = atributeFinder.FindAllMethods(moduleDefinition, COUNT_CALLS_THEM_ATTRIBUTE_NAME);

            foreach (var mt in mtCollection)
            {
                var item = new FieldDefinition(mt.MethodDefinition.Name + PROPERTY_POSTFIX, FieldAttributes.Public, moduleDefinition.TypeSystem.Int32);
                mt.TypeDefinition.Fields.Add(item);

                var instructions = mt.MethodDefinition.Body.Instructions;

                instructions.Insert(0, Instruction.Create(OpCodes.Nop));
                instructions.Insert(1, Instruction.Create(OpCodes.Ldarg_0));
                instructions.Insert(2, Instruction.Create(OpCodes.Dup));
                instructions.Insert(3, Instruction.Create(OpCodes.Ldfld, item));
                instructions.Insert(4, Instruction.Create(OpCodes.Ldc_I4_1));
                instructions.Insert(5, Instruction.Create(OpCodes.Add));
                instructions.Insert(6, Instruction.Create(OpCodes.Stfld, item));
            }
        }
    }
}