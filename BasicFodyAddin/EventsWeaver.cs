using System;
using System.Diagnostics;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace TeoVincent.BasicFodyAddin.Fody
{
    public class EventsWeaver : IWeaver
    {
        private readonly IAttributeFinder atributeFinder;
        private readonly ModuleDefinition moduleDefinition;

        public EventsWeaver(ModuleDefinition moduleDefinition, IAttributeFinder atributeFinder)
        {
            this.moduleDefinition = moduleDefinition;
            this.atributeFinder = atributeFinder;
        }

        public void Execute()
        {
            string eventAttribute = "TeoVincent.AssemblyToProcess.Events.EventAttribute";
            var typeCollection = atributeFinder.FindAllTypes(moduleDefinition, eventAttribute);

            foreach (var type in typeCollection)
            {
                Debug.WriteLine(type.Name);
                AddInheritance(type);
                AddBaseCtor(type);
            }
        }
        private void AddInheritance(TypeDefinition type)
        {
            var aeventType = moduleDefinition.GetTypes().First(x => x.Name == "AEvent");
            type.BaseType = aeventType;
        }

        private void AddBaseCtor(TypeDefinition type)
        {

        }
    }
}