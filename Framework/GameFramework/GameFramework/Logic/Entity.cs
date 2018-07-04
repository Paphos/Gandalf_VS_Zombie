using Microsoft.Xna.Framework;
using System;

namespace GameFramework.Logic
{
    public abstract class Entity
    {
        public Vector3 Position { get; protected set; }
        public Matrix Rotation { get; protected set; }

        protected World World
        {
            get;
            private set;
        }


        protected Entity(World world, Vector3 position)
        {
            World = world;
            Position = position;
            Rotation = Matrix.Identity;
        }

        public abstract void Update();

        protected void Summon(Entity newEntity)
        {
            World.AddToWorld(newEntity);
        }

        protected void Die()
        {
            World.RemoveFromWorld(this);
        }
    }
}
