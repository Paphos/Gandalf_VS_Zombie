using System;
using Microsoft.Xna.Framework;

using GameFramework.Logic;
using GameFramework.Graphic.Renderers;

namespace GameFramework.Graphic
{
    public abstract class WrapperGraphic
    {
        public Entity Entity { get; private set; }

        protected WrapperGraphic(Entity e)
        {
            Entity = e;
        }

        public Matrix CreateLocalSpace()
        {
            return Entity.Rotation * Matrix.CreateTranslation(Entity.Position);
        }

        public abstract void Draw(Renderer renderer);
            //renderer.AddToNextRendering(this);
    }
}
