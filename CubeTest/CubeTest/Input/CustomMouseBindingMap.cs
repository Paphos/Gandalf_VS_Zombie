using GameFramework.Input.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeTest
{
    class CustomMouseBindingMap : MouseBindingMap
    {
        public float Sensibilite { get; set; }

        public CustomMouseBindingMap(CustomActionList actions)
        {
            Sensibilite = 1 / 200f;

            this.BindAxisDelta(MouseAxis.X, actions.RotateCameraHorizontally, Sensibilite);
            this.BindAxisDelta(MouseAxis.Y, actions.RotateCameraVertically, Sensibilite);

            this.BindButton(MouseButton.LeftButton, ButtonState3.JustPressed, actions.Shoot);
            this.BindButton(MouseButton.RightButton, ButtonState3.Hold, actions.Shoot);
        }
    }
}
