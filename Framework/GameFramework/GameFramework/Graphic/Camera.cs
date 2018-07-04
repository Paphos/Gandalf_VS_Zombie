using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework.Graphic
{
    public class Camera
    {
        #region Attributs privés

        private Tracker _tracker;
        private float _radiansFov;
        private float _ratio;
        private bool _hasProjectionChanged;

        private Matrix _projection;

        #endregion


        #region Propriétés publiques

        public float Ratio
        {
            get { return _ratio; }
            set
            {
                _ratio = value;
                _hasProjectionChanged = true;
            }
        }

        public float FOV
        {
            get { return _radiansFov; }
            set
            {
                _radiansFov = value;
                _hasProjectionChanged = true;
            }
        }

        public Matrix MatrixProjection
        {
            get
            {
                if (_hasProjectionChanged)
                {
                    _projection = RecalculateMatrixProjection();
                }
                return _projection;
            }
        }

        public Matrix MatrixView
        {
            get { return this.CalculateMatrixView(); }
        }

        #endregion


        // Constructeur

        public Camera(GraphicSettings settings, float radianFov, Tracker tracker)
        {
            FOV = radianFov;
            Ratio = CalculateRatio(settings.WindowWidth, settings.WindowHeight);
            settings.SubscribeEventWindowSizeChange(this.OnWindowSizeChange);
            _tracker = tracker;
        }




        public void OnWindowSizeChange(int width, int height)
        {
            Ratio = CalculateRatio(width, height);
        }

        private float CalculateRatio(int width, int height)
        {
            return width / (float)height;
        }


        // TODO : à arranger
        private Matrix CalculateMatrixView()
        {
            Matrix rotationVerticale = Matrix.CreateFromAxisAngle(this.CalculateAxeDeRotationHorizontal(_tracker.rotationOrigin), _tracker.AngleRotationVertical);
            Matrix rotationHorizontale = Matrix.CreateRotationY(_tracker.AngleRotationHorizontal);

            Vector3 vecteurPosition = Vector3.Transform(_tracker.rotationOrigin, rotationVerticale);
            vecteurPosition = Vector3.Transform(vecteurPosition, rotationHorizontale);

            Vector3 cameraTargetPosition = _tracker.TrackingEntity.Position;
            Vector3 cameraPosition = vecteurPosition * _tracker.TrackingDistance + cameraTargetPosition;

            return Matrix.CreateLookAt(cameraPosition, cameraTargetPosition, Vector3.Up);
        }

        private Vector3 CalculateAxeDeRotationHorizontal(Vector3 vectorBase)
        {
            Vector3 tmp = new Vector3(vectorBase.X, 0, vectorBase.Z);
            Vector3 axeDeRotationHorizontal = Vector3.Transform(tmp, Matrix.CreateRotationY(MathHelper.PiOver2));
            axeDeRotationHorizontal.Normalize();
            return axeDeRotationHorizontal;
        }

        private Matrix RecalculateMatrixProjection()
        {
            _hasProjectionChanged = false;
            return Matrix.CreatePerspectiveFieldOfView(_radiansFov, _ratio, 0.1f, 1000.0f);
        }
    }
}
