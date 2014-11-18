using System;
using System.Collections.Generic;
using Mono.Cecil;

namespace TeoVincent.BasicFodyAddin.Fody
{
    public interface IWeaver
    {
        void Execute();
    }
    
    public class WeaverCollection : IWeaver
    {
        private readonly List<IWeaver> weavers;

        public WeaverCollection()
        {
            weavers = new List<IWeaver>();
        }

        public void Add(params IWeaver [] weavers)
        {
            foreach (var weaver in weavers)
                this.weavers.Add(weaver);
        }

        public void Execute()
        {
            foreach (var weaver in weavers)
                weaver.Execute();
        }
    }
}