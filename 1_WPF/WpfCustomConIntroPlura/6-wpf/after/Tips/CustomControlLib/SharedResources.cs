using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace CustomControlLib
{
    public static class SharedResources
    {
        static ComponentResourceKey _brushKey = new ComponentResourceKey(typeof(MyCustomControl), "CommonBrush");
        public static ComponentResourceKey CommonBrushKey
        {
            get { return _brushKey; }
        }
    }
}
