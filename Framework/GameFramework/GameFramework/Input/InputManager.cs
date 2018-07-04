using System;
using System.Collections.Generic;

using GameFramework.Graphic;
using GameFramework.Logic;

namespace GameFramework.Input
{
    public class InputManager
    {
        private DeviceHandler[] _devices;

        public InputManager(params DeviceHandler[] devices)
        {
            this._devices = devices;
        }

        public void Update()
        {
            foreach (DeviceHandler devices in _devices)
            {
                devices.Update();
            }
        }
    }
}
