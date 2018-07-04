using GameFramework.Logic;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeTest
{
    abstract class Personnage : EntityKind
    {
        public int LifePoint { get; protected set; }
        public int LifePointMax { get; protected set; }
        public bool IsDead { get; protected set; }

        public Personnage(World w, Vector3 pos, Kind kind)
            : base(w, pos, kind)
        {
            LifePoint = 1000;
            LifePointMax = 1000;
            IsDead = false;
        }

        public override void Update()
        {
            if (this.LifePoint <= 0)
            {
                IsDead = true;
                this.Die();
            }
        }

        public void TakeDamage(int amount)
        {
            LifePoint -= amount;
        }
    }
}
