using Mono.Cecil;

namespace TeoVincent.BasicFodyAddin.Fody
{
    public class MethodInType
    {
        public TypeDefinition TypeDefinition { get; set; }
        public MethodDefinition MethodDefinition { get; set; }
    }
}