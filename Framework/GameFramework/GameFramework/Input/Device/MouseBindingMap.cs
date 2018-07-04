using GameFramework.Input.Action;
using System;
using System.Collections.Generic;

namespace GameFramework.Input.Device
{
    public abstract class MouseBindingMap
    {
        //private Dictionary<MouseButton, ActionVoid> buttonActionMap = new Dictionary<MouseButton,ActionVoid>();

        private Dictionary<ButtonState3, Dictionary<MouseButton, ActionVoid>> buttonActionMap = new Dictionary<ButtonState3, Dictionary<MouseButton, ActionVoid>>();

        private Dictionary<MouseAxis, Tuple<ActionFloat, float>> axisActionMap = new Dictionary<MouseAxis,Tuple<ActionFloat,float>>();


        public MouseBindingMap()
        {
            foreach (ButtonState3 state in Enum.GetValues(typeof(ButtonState3)))
            {
                buttonActionMap.Add(state, new Dictionary<MouseButton, ActionVoid>());
            }
        }

        protected void BindButton(MouseButton button, ButtonState3 state, ActionVoid action)
        {
            buttonActionMap[state].Add(button, action);
        }

        protected void BindAxisDelta(MouseAxis axis, ActionFloat action, float sensibilite)
        {
            axisActionMap.Add(axis, new Tuple<ActionFloat,float>(action, sensibilite));
        }


        internal ActionVoid GetAction(MouseButton button, ButtonState3 state)
        {
            ActionVoid value;
            buttonActionMap[state].TryGetValue(button, out value);
            return value;
        }

        internal Tuple<ActionFloat, float> GetAction(MouseAxis axis)
        {
            Tuple<ActionFloat, float> value;
            axisActionMap.TryGetValue(axis, out value);
            return value;
        }
    }
}
