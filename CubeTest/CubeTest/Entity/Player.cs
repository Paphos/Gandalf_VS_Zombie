using GameFramework.Debug;
using GameFramework.Logic;
using Microsoft.Xna.Framework;
using System;

namespace CubeTest
{
    class Player : Personnage
    {
        private float _speed;

        public Player(World w, Vector3 pos, float speed) : base(w, pos, Kind.Gandalf) 
        {
            _speed = speed;
        }

        public void Move(Vector3 normalizedDisplacement)
        {
            this.Position += normalizedDisplacement * _speed;
        }

        public void ThrowProjectile(Vector3 projectileNormDeplacement, float speed)
        {
            this.SetRotationY(projectileNormDeplacement);
            this.Summon(new Projectile(World, Position, Kind.Projectile, projectileNormDeplacement, speed));
        }

        public void SetRotationY(Vector3 direction)
        {
            //direction.Normalize();
            this.Rotation = Matrix.CreateRotationY((float)Math.Atan2(direction.X, direction.Z));
        }

        public override void Update()
        {
            if (GameHost.debugDisplay)
            {
                if (this.LifePoint <= 0)
                {
                    DebugDisplay.Write("Collision avec Player", "PLAYER MORT !!");
                }
                else
                {
                    DebugDisplay.Write("Collision avec Player", this.World.Physic.GetEntitiesWhichCollidesWith(this).Count.ToString());
                }
            }

            base.Update();
        }
    }
}
