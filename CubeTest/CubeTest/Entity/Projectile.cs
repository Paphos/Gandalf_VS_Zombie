using GameFramework.Logic;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeTest
{
    public class Projectile : EntityKind
    {
        private const int MAXLIFETIME = 100;
        private int _damage = 10;

        private Vector3 _velocity;
        private float _speed;
        private int _lifetime = 0;

        public Projectile(World w, Vector3 pos, Kind kind, Vector3 velocity, float speed)
            : base(w, pos, kind)
        {
            _velocity = velocity;
            _speed = speed;
        }

        public override void Update()
        {
            bool die = false;

            _lifetime++;
            if (_lifetime >= MAXLIFETIME)
            {
                die = true;
            }

            this.Position += _velocity * _speed;

            List<Entity> targets = this.World.Physic.GetEntitiesWhichCollidesWith(this);

            foreach (Entity e in targets)
            {
                if (!(e is Player) && e is Personnage)
                {
                    ((Personnage)e).TakeDamage(this._damage);
                    die = true;
                }
            }

            if (die) { this.Die(); }
        }
    }
}
