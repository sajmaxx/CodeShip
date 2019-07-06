using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SMDependencyApp
{
    public class SamStackPanel : StackPanel
    {
                                                               //Use Register Method!
        public static DependencyProperty IsRedBackProperty =  DependencyProperty.Register("IsRedBack", typeof(bool), typeof(SamStackPanel), new PropertyMetadata(false, OnIsRedBackChanged, CoerceIsRedBackChanged));

        private static object CoerceIsRedBackChanged(DependencyObject d, object baseValue)
        {
            SamStackPanel lsamsp = d as SamStackPanel;
            if (lsamsp.IsRedBack == false)
            {
                return true;
            }
            else
            {
               return false;
            }
        }

        public bool IsRedBack
        {
            get { return (bool)GetValue(IsRedBackProperty); }
            set { SetValue(IsRedBackProperty,value); }
        }

        //Event Call back
        private static void OnIsRedBackChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            SamStackPanel smsp = source as SamStackPanel;


            if (smsp.IsRedBack == true)
            {
                smsp.Background = System.Windows.Media.Brushes.Red;
            }
            else
            {
                smsp.Background = System.Windows.Media.Brushes.LightBlue;
            }


        }
    }
}
