using Mono.Cecil;
using TeoVincent.BasicFodyAddin.Fody;

namespace TeoVincent.Tests.WeaverCreators
{
    abstract class WeaverCreator
    {
        protected readonly ModuleDefinition ModuleDefinition;

        protected WeaverCreator(ModuleDefinition moduleDefinition)
        {
            this.ModuleDefinition = moduleDefinition;
        }
        
        public abstract IWeaver WeaverFactory();
    }
}