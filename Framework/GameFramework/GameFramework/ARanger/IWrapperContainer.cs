using GameFramework.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.ARanger
{
    public interface IWrapperContainer<Wrapper> : IEnumerable<Wrapper>
    {
        void Add(Entity e);
        void Remove(Entity e);
        Wrapper this[Entity e]
        {
            get;
        }
    }
}
