using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.Logic.Physic
{
    public class BoundingSphereWP : WrapperPhysic
    {
        public Model Model { get; private set; }

        public BoundingSphereWP(Entity entity, Model model)
            : base(entity)
        {
            Model = model;
        }

        public override bool IsColliding(WrapperPhysic other)
        {
            BoundingSphereWP otherEntity = (BoundingSphereWP)other;

            for (int i = 0; i < this.Model.Meshes.Count; i++)
            {
                BoundingSphere c1BoundingSphere = this.Model.Meshes[i].BoundingSphere;
                c1BoundingSphere.Center += this.Entity.Position;

                for (int j = 0; j < otherEntity.Model.Meshes.Count; j++)
                {
                    BoundingSphere c2BoundingSphere = otherEntity.Model.Meshes[j].BoundingSphere;
                    c2BoundingSphere.Center += otherEntity.Entity.Position;

                    if (c1BoundingSphere.Intersects(c2BoundingSphere))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
