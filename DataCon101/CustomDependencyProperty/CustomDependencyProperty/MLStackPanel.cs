using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CustomDependencyProperty
{
    class MLStackPanel : StackPanel
    {

        //public static DependencyProperty IsBrownBkgrdProperty = DependencyProperty.Register("IsBrownBkgrd", typeof(bool), typeof(MLStackPanel), new PropertyMetadata(false, OnIsBrownBkgrdChanged, CoerceIsBrownBkgrdChanged));

        public static DependencyProperty IsBrownBkgrdProperty = DependencyProperty.Register("IsBrownBkgrd", typeof(bool), typeof(MLStackPanel));

        private static object CoerceIsBrownBkgrdChanged(DependencyObject d, object baseValue)
        {
            MLStackPanel m = d as MLStackPanel;
            if (m.IsBrownBkgrd == false)
            {
                MessageBox.Show("The IsBrownBkgrd depdendency property is being changed to true");
                return true;
            }
            else
            {
                MessageBox.Show("The IsBrownBkgrd depdendency property is being changed to false");
                return false;
            }

        }

        public bool IsBrownBkgrd
        {
            get { return (bool)GetValue(IsBrownBkgrdProperty); }
            set { SetValue(IsBrownBkgrdProperty, value); }
        }

        private static void OnIsBrownBkgrdChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            MLStackPanel msp = source as MLStackPanel;

            if (msp.IsBrownBkgrd == true)
            {
                msp.Background = System.Windows.Media.Brushes.BurlyWood;
            }
            else
            {
                msp.Background = System.Windows.Media.Brushes.LightGray;
            }

        }
       
    }
}
