using GameFramework.Logic;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeTest
{
    class MonstreFollower : Personnage
    {
        private Personnage _entityToFollow;
        private float _speed = 0.1f;

        public MonstreFollower(World w, Vector3 pos, Kind kind, Personnage entityToFollow) 
            : base(w, pos, kind)
        {
            LifePoint = 10;
            LifePointMax = 10;
            _entityToFollow = entityToFollow;
        }

        public override void Update()
        {
            if (!_entityToFollow.IsDead)
            {
                // Déplacement

                Vector3 deplacement = VectorFrom2Position(this.Position, _entityToFollow.Position);
                deplacement.Normalize();

                this.Position += deplacement * _speed;

                this.Rotation = Matrix.CreateRotationY((float)Math.Atan2(deplacement.X, deplacement.Z));

                // Collision et dégats

                if (this.World.Physic.IsColliding(this, _entityToFollow))
                {
                    _entityToFollow.TakeDamage(1);
                }
            }

            base.Update();
        }

        // TODO : à déplacer

        public Vector3 VectorFrom2Position(Vector3 posA, Vector3 posB)
        {
            return new Vector3(posB.X - posA.X, posB.Y - posB.Y, posB.Z - posA.Z);
        }
    }
}
