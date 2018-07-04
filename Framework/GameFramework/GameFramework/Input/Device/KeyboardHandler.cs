using GameFramework.Input.Action;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace GameFramework.Input.Device
{
    public class KeyboardHandler : DeviceHandler
    {
        private KeyboardBindingMap _bindingMap;
        private List<Keys> _previousKeyPressed = new List<Keys>();

        public KeyboardHandler(KeyboardBindingMap bindingMap)
        {
            _bindingMap = bindingMap;
        }

        public sealed override void Update()
        {
            ButtonState3 state;
            List<Keys> currentKeyPressed = new List<Keys>();
            currentKeyPressed.AddRange(Keyboard.GetState().GetPressedKeys());

            foreach (Keys current in currentKeyPressed)
            {
                if (_previousKeyPressed.Contains(current))
                {
                    state = ButtonState3.Hold;
                    _previousKeyPressed.Remove(current);
                }
                else
                {
                    state = ButtonState3.JustPressed;
                }
                ExecuteAction(current, state);
            }

            foreach (Keys previous in _previousKeyPressed)
            {
                ExecuteAction(previous, ButtonState3.JustReleased);
            }

            _previousKeyPressed = currentKeyPressed;
        }

        private void ExecuteAction(Keys key, ButtonState3 state)
        {
            ActionVoid action = _bindingMap.GetAction(key, state);
            if (action != null)
            {
                action.Execute();
            }
        }
    }
}
