using Mono.Cecil;
using TeoVincent.BasicFodyAddin.Fody;

namespace TeoVincent.Tests.WeaverCreators
{
    class MethodCallsCounterWeaverCreator : WeaverCreator
    {
        public MethodCallsCounterWeaverCreator(ModuleDefinition moduleDefinition) 
            : base(moduleDefinition)
        {
        }

        public override IWeaver WeaverFactory()
        {
            var attributeFinder = new AttributeFinder();
            var methodCallsCounterWeaver = new MethodCallsCounterWeaver(attributeFinder, ModuleDefinition);
            return methodCallsCounterWeaver;
        }
    }

    class EventsWeaverCreator : WeaverCreator
    {
        public EventsWeaverCreator(ModuleDefinition moduleDefinition) 
            : base(moduleDefinition)
        {

        }

        public override IWeaver WeaverFactory()
        {
            return new EventsWeaver(ModuleDefinition);
        }
    }
}