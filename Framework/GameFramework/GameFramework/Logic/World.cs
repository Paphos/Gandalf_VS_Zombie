using GameFramework.ARanger;
using GameFramework.Logic.Physic;
using System;
using System.Collections.Generic;

namespace GameFramework.Logic
{
    public abstract class World
    {
        #region Gestion des events
        public delegate void Adding(Entity e);
        public delegate void Removing(Entity e);
        private event Adding AddEntityEvent;
        private event Removing RemoveEntityEvent;

        public void Subscribe(Adding addMethod, Removing removeMethod)
        {
            AddEntityEvent += addMethod;
            RemoveEntityEvent += removeMethod;
        }
        #endregion

        #region Gestion de la liste des Entity
        private List<Entity> entities = new List<Entity>();
        private List<Entity> entitiesToAdd = new List<Entity>();
        private List<Entity> entitiesToRemove = new List<Entity>();

        public int EntityCount
        {
            get { return entities.Count; }
        }

        private void CommitEntitiesCreation()
        {
            foreach (Entity e in entitiesToAdd)
            {
                entities.Add(e);
                if (AddEntityEvent != null)
                {
                    AddEntityEvent(e);
                }
            }
            entitiesToAdd.Clear();
        }

        private void CommitEntitiesDeath()
        {
            foreach (Entity e in entitiesToRemove)
            {
                if (RemoveEntityEvent != null)
                {
                    RemoveEntityEvent(e);
                }
                entities.Remove(e);
            }
            entitiesToRemove.Clear();
        }
        #endregion

        public WorldPhysic Physic { get; private set; }

        public World(IGenerator<WrapperPhysic> generator)
        {
            Physic = new WorldPhysic(generator);
            this.Subscribe(Physic.Add, Physic.Remove);
        }

        public abstract void Initialize();

        public virtual void AddToWorld(Entity e)
        {
            this.entitiesToAdd.Add(e);
        }

        public virtual void RemoveFromWorld(Entity e)
        {
            this.entitiesToRemove.Add(e);
        }


        public virtual void Update()
        {
            foreach (Entity e in entities)
            {
            e.Update();
            }

            if (entitiesToAdd.Count > 0) { CommitEntitiesCreation(); }
            if (entitiesToRemove.Count > 0) { CommitEntitiesDeath(); }
        }
    }
}
