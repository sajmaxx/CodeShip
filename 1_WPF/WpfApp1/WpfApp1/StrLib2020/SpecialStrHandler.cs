using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace DataBinding101.StrLib2020
{
    public static class SpecialStrHandler
    {
        public static string Encrypt(this string inputS)
        {
            string something = inputS;

            return something.Replace('a','b');

        }

        public static string Reverser(this string inputS)
        {
            string reverse = "";
            for (var k = inputS.Length - 1; k >= 0; k--)
            {
                reverse += inputS[k];
            }
            return reverse;
        }
    }

    
}
