using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.Input.Action
{
    public class ActionFloat
    {
        public delegate void MethodFloat(float f);
        private MethodFloat _method;

        public ActionFloat(MethodFloat method)
        {
            _method = method;
        }

        public void Execute(float f)
        {
            _method(f);
        }
    }
}
