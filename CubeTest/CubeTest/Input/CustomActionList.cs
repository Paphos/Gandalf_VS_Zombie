using GameFramework.Graphic;
using GameFramework.Input;
using GameFramework.Input.Action;
using Microsoft.Xna.Framework;
using System;

namespace CubeTest
{
    class CustomActionList : ActionList
    {
        public ActionVoid PlayerForward { get; private set; }
        public ActionVoid PlayerBackward { get; private set; }
        public ActionVoid PlayerRight { get; private set; }
        public ActionVoid PlayerLeft { get; private set; }
        public ActionFloatFloat CameraRotation { get; private set; }
        public ActionFloat RotateCameraHorizontally { get; private set; }
        public ActionFloat RotateCameraVertically { get; private set; }

        public ActionVoid Shoot { get; private set; }
        public ActionVoid Pause { get; private set; }

        private CustomWorld _world;
        private Tracker _tracker;

        public CustomActionList(Game game, GraphicSettings setting, CustomWorld world, Tracker tracker)
            : base(game,setting)
        {
            _world = world;
            _tracker = tracker;
            PlayerForward = new ActionVoid(this.PlayerMoveForward);
            PlayerRight = new ActionVoid(this.PlayerMoveRight);
            PlayerBackward = new ActionVoid(this.PlayerMoveBackward);
            PlayerLeft = new ActionVoid(this.PlayerMoveLeft);
            CameraRotation = new ActionFloatFloat(this.RotateCamera);
            RotateCameraHorizontally = new ActionFloat(this.M_RotateCameraX);
            RotateCameraVertically = new ActionFloat(this.M_RotateCameraY);
            Pause = new ActionVoid(this.M_Pause);

            Shoot = new ActionVoid(this.MethodShoot);
        }

        private void PlayerMoveForward()
        {
            PlayerMoveAndRotate(_tracker.CalculateNormalizeDeplacementFromDirection(Direction.Haut));
        }

        private void PlayerMoveRight()
        {
            PlayerMoveAndRotate(_tracker.CalculateNormalizeDeplacementFromDirection(Direction.Droite));
        }

        private void PlayerMoveBackward()
        {
            PlayerMoveAndRotate(_tracker.CalculateNormalizeDeplacementFromDirection(Direction.Bas));
        }

        private void PlayerMoveLeft()
        {
            PlayerMoveAndRotate(_tracker.CalculateNormalizeDeplacementFromDirection(Direction.Gauche));
        }

        private void PlayerMoveAndRotate(Vector3 normDeplacement)
        {
            _world.Player.Move(normDeplacement);
            _world.Player.SetRotationY(normDeplacement);
        }

        private void RotateCamera(float x, float y)
        {
            this.M_RotateCameraX(x);
            this.M_RotateCameraY(y);
        }

        private void M_RotateCameraX(float x)
        {
            _tracker.AngleRotationHorizontal -= x;
        }

        private void M_RotateCameraY(float y)
        {
            _tracker.AngleRotationVertical -= y;
        }

        private void MethodShoot()
        {
            _world.Player.ThrowProjectile(_tracker.CalculateNormalizeDeplacementFromDirection(Direction.Haut), 0.5f);
        }

        private void M_Pause()
        {
            _world.Pause();
        }
    }
}
