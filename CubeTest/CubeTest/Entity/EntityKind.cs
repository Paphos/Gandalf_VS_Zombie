using GameFramework.Logic;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeTest
{
    public abstract class EntityKind : Entity
    {
        public Kind Kind { get; private set; }

        public EntityKind(World w, Vector3 pos, Kind kind) : base(w,pos)
        {
            Kind = kind;
        }
    }
}
