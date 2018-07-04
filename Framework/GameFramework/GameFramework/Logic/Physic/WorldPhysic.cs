using GameFramework.ARanger;
using System;
using System.Collections.Generic;

namespace GameFramework.Logic.Physic
{
    public class WorldPhysic
    {
        private SimpleWrapperContainer<WrapperPhysic> _container;

        internal WorldPhysic(IGenerator<WrapperPhysic> generator)
        {
            _container = new SimpleWrapperContainer<WrapperPhysic>(generator);
        }

        internal void Add(Entity e)
        {
            _container.Add(e);
        }

        internal void Remove(Entity e)
        {
            _container.Remove(e);
        }

        public List<Entity> GetEntitiesWhichCollidesWith(Entity e)
        {
            WrapperPhysic subject = _container[e];
            List<Entity> collidesWith = new List<Entity>();

            foreach (WrapperPhysic wp in _container)
            {
                if (wp != subject && wp.IsColliding(subject))
                {
                    collidesWith.Add(wp.Entity);
                }
            }

            return collidesWith;
        }

        public bool IsColliding(Entity a, Entity b)
        {
            WrapperPhysic wrapperA = _container[a];
            WrapperPhysic wrapperB = _container[b];

            return wrapperA.IsColliding(wrapperB);
        }
    }
}
