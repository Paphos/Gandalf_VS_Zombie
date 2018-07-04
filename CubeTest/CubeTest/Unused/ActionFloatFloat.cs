using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.Input.Action
{
    public class ActionFloatFloat
    {
        public delegate void MethodFloatFloat(float a, float b);
        private MethodFloatFloat _method;

        public ActionFloatFloat(MethodFloatFloat method)
        {
            _method = method;
        }

        public void Execute(float a, float b)
        {
            _method(a,b);
        }
    }
}
