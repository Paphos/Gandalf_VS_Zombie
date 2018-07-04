using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameFramework.Logic;

namespace GameFramework.Graphic
{
    public class Tracker
    {
        public readonly Vector3 rotationOrigin = new Vector3(0, 0, 1);


        #region Attributs privés

        private float _angleRotationVertical = -0.5f;
        private float _angleRotationHorizontal = 0f;
        #endregion

        #region Propriétés

        public Entity TrackingEntity { get; set; }
        public float TrackingDistance { get; set; }

        public float AngleRotationVertical
        {
            get { return _angleRotationVertical; }
            set
            {
                if (value > -(MathHelper.PiOver2) && value < MathHelper.PiOver2)
                {
                    _angleRotationVertical = value;
                }
            }
        }
        public float AngleRotationHorizontal
        {
            get { return _angleRotationHorizontal; }
            set { _angleRotationHorizontal = value; }
        }

        #endregion


        // Constructeur

        public Tracker(Entity target, float trackingDistance)
        {
            this.TrackingEntity = target;
            this.TrackingDistance = trackingDistance;
        }




        public Vector3 CalculateNormalizeDeplacementFromDirection(Direction direction)
        {
            Matrix matrixRotationHorizontale = Matrix.CreateRotationY(AngleRotationHorizontal + this.CalculateAngleFromDirection(direction));
            return Vector3.Transform(rotationOrigin, matrixRotationHorizontale);
        }

        private float CalculateAngleFromDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Haut: return MathHelper.Pi;
                case Direction.Droite: return MathHelper.PiOver2;
                case Direction.Gauche: return MathHelper.PiOver2 * 3;
                default: return 0f; // Direction.Bas
            }
        }
    }

    public enum Direction { Haut, Bas, Droite, Gauche }
}

