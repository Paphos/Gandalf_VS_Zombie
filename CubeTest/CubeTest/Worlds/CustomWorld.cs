using GameFramework.ARanger;
using GameFramework.Debug;
using GameFramework.Logic;
using GameFramework.Logic.Physic;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeTest
{
    class CustomWorld : World
    {
        public Player Player { get; private set; }

        public CustomWorld(IGenerator<WrapperPhysic> generator)
            : base(generator)
        {
            Player = new Player(this, Vector3.Zero, 0.1f);
        }

        private int _monsterCount = 0;
        private int _monsterMax = 10;

        public override void Initialize()
        {
            this.AddToWorld(this.Player);

            SpawnMonster();

        }



        private void SpawnMonster()
        {
            while (_monsterCount < _monsterMax)
            {
                MonstreFollower monstre = new MonstreFollower(this, GetRandomPosition(), Kind.Zombie, this.Player);
                this.AddToWorld(new MonstreFollower(this, GetRandomPosition(), Kind.Zombie, this.Player));
            }
        }

        private Random random = new Random();
        private float dist = 20f;

        private Vector3 GetRandomPosition()
        {
            double angle = random.NextDouble() * MathHelper.TwoPi;
            return new Vector3((float)(Math.Cos(angle) * dist), 0f, (float)(Math.Sin(angle) * dist));
        }

        public override void Update()
        {
            if (!_paused)
            {
                SpawnMonster();
                DebugDisplay.Write("Entities.Count", this.EntityCount.ToString());
                base.Update();
            }
        }

        private bool _paused = false;

        public void Pause()
        {
            _paused = !_paused;
        }


        public override void AddToWorld(Entity e)
        {
            if (e is MonstreFollower)
            {
                _monsterCount++;
            }

            base.AddToWorld(e);
        }

        public override void RemoveFromWorld(Entity e)
        {
            if (e is MonstreFollower)
            {
                _monsterCount--;
            }

            base.RemoveFromWorld(e);
        }

    }
}
