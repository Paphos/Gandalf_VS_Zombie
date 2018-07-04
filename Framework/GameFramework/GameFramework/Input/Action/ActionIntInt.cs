using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.Input.Action
{
    public class ActionIntInt
    {
        public delegate void MethodIntInt(int a, int b);
        private MethodIntInt _method;

        public ActionIntInt(MethodIntInt method)
        {
            _method = method;
        }

        public void Execute(int a, int b)
        {
            _method(a,b);
        }
    }
}
