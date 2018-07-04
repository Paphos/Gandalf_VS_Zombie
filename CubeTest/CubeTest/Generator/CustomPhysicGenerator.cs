using GameFramework.ARanger;
using GameFramework.Logic;
using GameFramework.Logic.Physic;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeTest
{
    class CustomPhysicGenerator : IGenerator<WrapperPhysic>
    {
        private CustomContentLoader _loader;

        public CustomPhysicGenerator(CustomContentLoader loader)
        {
            this._loader = loader;
        }
        public WrapperPhysic Generate(Entity e)
        {
            EntityKind ek = (EntityKind)e;

            return new BoundingSphereWP(e, _loader.Get<Model>(ek.Kind));
        }
    }
}
