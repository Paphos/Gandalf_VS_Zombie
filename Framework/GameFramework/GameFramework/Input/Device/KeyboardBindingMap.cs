using GameFramework.Input.Action;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace GameFramework.Input.Device
{
    public abstract class KeyboardBindingMap
    {
        private Dictionary<ButtonState3, Dictionary<Keys, ActionVoid>> keyMap = new Dictionary<ButtonState3, Dictionary<Keys, ActionVoid>>();

        public KeyboardBindingMap(ActionList actions)
        {
            foreach (ButtonState3 state in Enum.GetValues(typeof(ButtonState3)))
            {
                keyMap.Add(state, new Dictionary<Keys, ActionVoid>());
            }

            this.Bind(Keys.Escape, ButtonState3.JustPressed, actions.Exit);
            this.Bind(Keys.F11, ButtonState3.JustPressed, actions.ToggleFullScreen);
        }

        protected void Bind(Keys key, ButtonState3 state, ActionVoid action)
        {
            keyMap[state].Add(key, action);
        }

        internal ActionVoid GetAction(Keys key, ButtonState3 state)
        {
            ActionVoid value;
            keyMap[state].TryGetValue(key, out value);
            return value;
        }
    }
}
