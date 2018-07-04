using GameFramework.Graphic;
using GameFramework.Graphic.Renderers;
using GameFramework.Logic;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.Graphic
{
    public class ModelWG : WrapperGraphic
    {
        public Model Model { get; private set; }

        public ModelWG(Entity entity, Model model)
            : base(entity)
        {
            Model = model;
        }

        public override void Draw(Renderer renderer)
        {
            renderer.DrawModel(this);
        }
    }
}
