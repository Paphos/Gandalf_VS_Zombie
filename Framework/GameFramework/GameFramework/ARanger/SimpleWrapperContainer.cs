using GameFramework.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.ARanger
{
    public class SimpleWrapperContainer<Wrapper> : IWrapperContainer<Wrapper>
    {
        private Dictionary<Entity, Wrapper> _dico = new Dictionary<Entity, Wrapper>();
        private IGenerator<Wrapper> _generator;

        public SimpleWrapperContainer(IGenerator<Wrapper> generator){
            _generator = generator;
        }

        public void Add(Entity e)
        {
            _dico.Add(e, _generator.Generate(e));
        }

        public void Remove(Entity e)
        {
            _dico.Remove(e);
        }

        public Wrapper this[Entity e]
        {
            get { return _dico[e]; }
        }

        public IEnumerator<Wrapper> GetEnumerator()
        {
            return _dico.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
