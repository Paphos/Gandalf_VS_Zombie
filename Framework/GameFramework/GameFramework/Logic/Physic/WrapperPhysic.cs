using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.Logic.Physic
{
    public abstract class WrapperPhysic
    {
        public Entity Entity { get; private set; }

        protected WrapperPhysic(Entity e)
        {
            Entity = e;
        }

        public abstract bool IsColliding(WrapperPhysic other);
    }
}
