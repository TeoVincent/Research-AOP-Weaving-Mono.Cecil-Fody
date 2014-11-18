using System;
using Mono.Cecil;

namespace TeoVincent.BasicFodyAddin.Fody
{
    public class EventsWeaver : IWeaver
    {
        private readonly ModuleDefinition moduleDefinition;

        public EventsWeaver(ModuleDefinition moduleDefinition)
        {
            this.moduleDefinition = moduleDefinition;
        }

        public void Execute()
        {
            
        }
    }
}