using GameFramework.Input.Device;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace CubeTest
{
    class CustomKeyboardBindingMap : KeyboardBindingMap
    {
        public CustomKeyboardBindingMap(CustomActionList actions) : base(actions)
        {
            this.Bind(Keys.Z, ButtonState3.Hold, actions.PlayerForward);
            this.Bind(Keys.D, ButtonState3.Hold, actions.PlayerRight);
            this.Bind(Keys.Q, ButtonState3.Hold, actions.PlayerLeft);
            this.Bind(Keys.S, ButtonState3.Hold, actions.PlayerBackward);

            this.Bind(Keys.Space, ButtonState3.JustPressed, actions.Pause);
        }
    }
}
