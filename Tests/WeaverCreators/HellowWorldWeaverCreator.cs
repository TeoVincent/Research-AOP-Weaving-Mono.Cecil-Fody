using Mono.Cecil;
using TeoVincent.BasicFodyAddin.Fody;

namespace TeoVincent.Tests.WeaverCreators
{
    class HellowWorldWeaverCreator : WeaverCreator
    {
        public HellowWorldWeaverCreator(ModuleDefinition moduleDefinition) 
            : base(moduleDefinition)
        {
        }

        public override IWeaver WeaverFactory()
        {
            return new HellowWorldWeaver(ModuleDefinition);
        }
    }
}