using Microsoft.Xna.Framework;
using System;

namespace GameFramework.Graphic.Renderers
{
    public abstract class Renderer
    {
        public abstract void Render();

        public abstract void DrawModel(ModelWG modelWG);
        //public abstract void DrawSprite(SpriteWG spriteWG);

        public abstract void WriteAt(Vector3 worldPosition, string msg);
        public abstract void WriteAt(Vector2 screenPosition, string msg);
    }
}
