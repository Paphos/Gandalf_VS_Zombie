using GameFramework.Logic.Physic;
using System;

namespace GameFramework.Logic
{
    public class LogicManager
    {
        public World World
        {
            get;
            private set;
        }

        public WorldPhysic Physic
        {
            get;
            private set;
        }

        public LogicManager(World world)
        {
            World = world;
        }

        public void Start()
        {
            World.Initialize();
        }

        public void Update()
        {
            World.Update();
        }
    }
}
