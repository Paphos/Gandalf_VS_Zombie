using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.Input.Action
{
    public class ActionVoid
    {
        public delegate void MethodVoid();
        private MethodVoid _method;

        public ActionVoid(MethodVoid method)
        {
            _method = method;
        }

        public void Execute()
        {
            _method();
        }
    }
}
