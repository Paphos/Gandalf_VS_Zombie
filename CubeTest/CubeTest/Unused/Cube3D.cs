using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

using GameFramework.Graphic;
using GameFramework.Logic;

/*
namespace CubeTest
{
    class Cube3D : EntityGraphic3D
    {
        public Cube3D(Entity entity) : base(entity, BuildVertices(), 12) { }

        private static VertexPositionColor[] BuildVertices()
        {
            int i = 0;
            Color thisColor = Color.Black;

            Vector3[] sommets = new Vector3[8];

            sommets[i++] = new Vector3(-0.5f, -0.5f, -0.5f);
            sommets[i++] = new Vector3(0.5f, -0.5f, -0.5f);
            sommets[i++] = new Vector3(-0.5f, 0.5f, -0.5f);
            sommets[i++] = new Vector3(0.5f, 0.5f, -0.5f);

            sommets[i++] = new Vector3(-0.5f, -0.5f, 0.5f);
            sommets[i++] = new Vector3(0.5f, -0.5f, 0.5f);
            sommets[i++] = new Vector3(-0.5f, 0.5f, 0.5f);
            sommets[i++] = new Vector3(0.5f, 0.5f, 0.5f);


            VertexPositionColor[] _vertices = new VertexPositionColor[36];

            i = 0;

            // Face avant
            _vertices[i++].Position = sommets[1];
            _vertices[i++].Position = sommets[2];
            _vertices[i++].Position = sommets[0];

            _vertices[i++].Position = sommets[3];
            _vertices[i++].Position = sommets[2];
            _vertices[i++].Position = sommets[1];

            // Face arrière
            _vertices[i++].Position = sommets[6];
            _vertices[i++].Position = sommets[5];
            _vertices[i++].Position = sommets[4];

            _vertices[i++].Position = sommets[6];
            _vertices[i++].Position = sommets[7];
            _vertices[i++].Position = sommets[5];

            // Face gauche
            _vertices[i++].Position = sommets[4];
            _vertices[i++].Position = sommets[0];
            _vertices[i++].Position = sommets[2];

            _vertices[i++].Position = sommets[6];
            _vertices[i++].Position = sommets[4];
            _vertices[i++].Position = sommets[2];

            // Face droite
            _vertices[i++].Position = sommets[5];
            _vertices[i++].Position = sommets[3];
            _vertices[i++].Position = sommets[1];

            _vertices[i++].Position = sommets[3];
            _vertices[i++].Position = sommets[5];
            _vertices[i++].Position = sommets[7];

            // Face dessus
            _vertices[i++].Position = sommets[3];
            _vertices[i++].Position = sommets[6];
            _vertices[i++].Position = sommets[2];

            _vertices[i++].Position = sommets[7];
            _vertices[i++].Position = sommets[6];
            _vertices[i++].Position = sommets[3];

            // Face dessous
            _vertices[i++].Position = sommets[4];
            _vertices[i++].Position = sommets[1];
            _vertices[i++].Position = sommets[0];

            _vertices[i++].Position = sommets[1];
            _vertices[i++].Position = sommets[4];
            _vertices[i++].Position = sommets[5];


            for (i = 0; i < _vertices.Length; i++)
            {
                switch (i)
                {
                    case 0: thisColor = Color.Blue; break;
                    case 6: thisColor = Color.Yellow; break;
                    case 12: thisColor = Color.PaleGreen; break;
                    case 18: thisColor = Color.White; break;
                    case 24: thisColor = Color.Magenta; break;
                    case 30: thisColor = Color.Orange; break;
                }

                thisColor = thisColor * 0.95f;

                _vertices[i].Color = thisColor;
            }

            return _vertices;
        }
    }
}
*/