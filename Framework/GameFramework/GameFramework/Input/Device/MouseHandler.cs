using GameFramework.Input.Action;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.Input.Device
{
    public class MouseHandler : DeviceHandler
    {
        private MouseBindingMap _bindingMap;
        private List<MouseButton> _previousButtonPressed = new List<MouseButton>();

        private bool _cursorLocked;
        private Point _mouseLockedPosition;

        public bool CursorLocked
        {
            get { return _cursorLocked; }
            set
            {
                if (_cursorLocked = value)
                {
                    //_mouseLockedPosition = Mouse.GetState().Position;
                    _mouseLockedPosition = new Point(500);
                }
            }
        }

        public MouseHandler(MouseBindingMap bindingMap, bool lockCursor)
        {
            _bindingMap = bindingMap;
            CursorLocked = lockCursor;
        }

        public sealed override void Update()
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState == null) { return; }

            /*
            if(!CursorLocked && _bindingMap.MousePositionAction != null){
                ActionFloatFloat action = _bindingMap.MousePositionAction.Item1;
                float sensibilite = _bindingMap.MousePositionAction.Item2;
                action.Execute(mouseState.Position.X * sensibilite, mouseState.Position.Y * sensibilite);
            }
             */ 

            if (CursorLocked)
            {
                int deltaX = mouseState.Position.X - _mouseLockedPosition.X;
                int deltaY = mouseState.Position.Y - _mouseLockedPosition.Y;

                /*
                if (_bindingMap.MouseDeltaPositionAction != null)
                {
                    ActionFloatFloat actionXY = _bindingMap.MouseDeltaPositionAction.Item1;
                    float sensibiliteXY = _bindingMap.MouseDeltaPositionAction.Item2;
                    actionXY.Execute(deltaX * sensibiliteXY, deltaY * sensibiliteXY);
                }
                */

                Tuple<ActionFloat, float> tuple;

                if ((tuple = _bindingMap.GetAction(MouseAxis.X)) != null)
                {
                    ActionFloat actionX = tuple.Item1;
                    float sensibiliteX = tuple.Item2;
                    actionX.Execute(deltaX * sensibiliteX);
                }

                if ((tuple = _bindingMap.GetAction(MouseAxis.Y)) != null)
                {
                    ActionFloat actionY = tuple.Item1;
                    float sensibiliteY = tuple.Item2;
                    actionY.Execute(deltaY * sensibiliteY);
                }

                SetCursorPosition(_mouseLockedPosition.X, _mouseLockedPosition.Y);
            }

            List<MouseButton> _currentButtonPressed = new List<MouseButton>();

            if (mouseState.LeftButton == ButtonState.Pressed) {
                _currentButtonPressed.Add(MouseButton.LeftButton);
            }

            if (mouseState.MiddleButton == ButtonState.Pressed) {
                _currentButtonPressed.Add(MouseButton.MiddleButton);
            }

            if (mouseState.RightButton == ButtonState.Pressed) {
                _currentButtonPressed.Add(MouseButton.RightButton);
            }

            foreach (MouseButton button in Enum.GetValues(typeof(MouseButton)))
            {
                if (_currentButtonPressed.Contains(button))
                {
                    if (_previousButtonPressed.Contains(button))
                    {
                        ExecuteAction(button, ButtonState3.Hold);
                    }
                    else
                    {
                        ExecuteAction(button, ButtonState3.JustPressed);
                    }
                }
                else
                {
                    if (_previousButtonPressed.Contains(button))
                    {
                        ExecuteAction(button, ButtonState3.JustReleased);
                    }
                }
            }

            _previousButtonPressed = _currentButtonPressed;
        }

        private void ExecuteAction(MouseButton button, ButtonState3 state)
        {
            ActionVoid action = _bindingMap.GetAction(button, state);
            if (action != null)
            {
                action.Execute();
            }
        }

        private void SetCursorPosition(int x, int y)
        {
            try
            {
                Mouse.SetPosition(x,y);
            }
            catch (ObjectDisposedException ex) { }
        }
    }

    public enum MouseButton
    {
        LeftButton,
        RightButton,
        MiddleButton
    }

    public enum MouseAxis
    {
        X,
        Y
    }
}
