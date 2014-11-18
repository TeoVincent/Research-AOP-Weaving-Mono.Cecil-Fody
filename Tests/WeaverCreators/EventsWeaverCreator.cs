using Mono.Cecil;
using TeoVincent.BasicFodyAddin.Fody;

namespace TeoVincent.Tests.WeaverCreators
{
    class EventsWeaverCreator : WeaverCreator
    {
        public EventsWeaverCreator(ModuleDefinition moduleDefinition) 
            : base(moduleDefinition)
        {

        }

        public override IWeaver WeaverFactory()
        {
            return new EventsWeaver(ModuleDefinition, new AttributeFinder());
        }
    }
}