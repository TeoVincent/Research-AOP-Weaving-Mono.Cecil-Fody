using System.Collections.Generic;
using Mono.Cecil;

namespace TeoVincent.BasicFodyAddin.Fody
{
    public interface IAttributeFinder
    {
        IEnumerable<MethodInType> FindAllMethods(ModuleDefinition moduleDefinition, string attributeFullName);
    }
    
    public class AttributeFinder : IAttributeFinder
    {
        public IEnumerable<MethodInType> FindAllMethods(ModuleDefinition moduleDefinition, string attributeFullName)
        {
            var mtCollection = new List<MethodInType>();
            var types = moduleDefinition.GetTypes();
            
            foreach (var type in types)
            {
                foreach (var method in type.Methods)
                {
                    foreach (var attribute in method.CustomAttributes)
                    {
                        if (attribute.AttributeType.FullName == attributeFullName)
                        {
                            var typeMethodDefinition = new MethodInType { TypeDefinition = type, MethodDefinition = method };
                            mtCollection.Add(typeMethodDefinition);
                        }
                    }
                }
            }

            return mtCollection;
        }
    }
}