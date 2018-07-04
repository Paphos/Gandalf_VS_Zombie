using GameFramework.Graphic;
using GameFramework.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

/*
namespace CubeTest
{
    class EntityGraphic3D : WrapperGraphic
    {
        public PrimitiveType _primitiveType;
        public VertexPositionColor[] _vertices;
        public int _firstVertexIndex;
        public int _nbPrimitives;
        
        public EntityGraphic3D(Entity entity, VertexPositionColor[] vertices, int nbPrimitives, int firstVertexIndex = 0, PrimitiveType primitiveType = PrimitiveType.TriangleList)
        : base(entity)
        {
            _primitiveType = primitiveType;
            _vertices = vertices;
            _nbPrimitives = nbPrimitives;
            _firstVertexIndex = firstVertexIndex;
        }

        public override void Draw(Renderer renderer)
        {
            renderer.AddToNextRendering(this);
        }
    }
}
*/