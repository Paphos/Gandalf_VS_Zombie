using GameFramework.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.ARanger
{
    public interface IGenerator<Wrapper>
    {
        Wrapper Generate(Entity e);
    }
}
