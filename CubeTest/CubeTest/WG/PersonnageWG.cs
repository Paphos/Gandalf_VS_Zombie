using GameFramework.Graphic;
using GameFramework.Graphic.Renderers;
using GameFramework.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeTest
{
    class PersonnageWG : ModelWG
    {
        static private Vector3 labelPosition = new Vector3(0, 1.2f, 0); 

        public PersonnageWG(Entity entity, Model model)
            : base(entity, model) { }

        public override void Draw(Renderer renderer)
        {
            Personnage perso = (Personnage)this.Entity;
            string pv = String.Format("{0}/{1}",perso.LifePoint, perso.LifePointMax);
            Vector3 position = this.Entity.Position + labelPosition;
            renderer.WriteAt(position, pv);
            base.Draw(renderer);
        }
    }
}
