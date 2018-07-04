using GameFramework.Logic;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeTest
{
    class Monstre : Personnage
    {
        public Monstre(World w, Vector3 pos, Kind kind) : base(w,pos,kind){}

        public override void Update()
        {
            Entity player = ((CustomWorld)this.World).Player;
            if (this.World.Physic.IsColliding(this, player))
            {
                this.Rotation = Matrix.CreateRotationY(0.1f) * this.Rotation;
                (this.LifePoint)--;
            }

            base.Update();
        }
    }
}
