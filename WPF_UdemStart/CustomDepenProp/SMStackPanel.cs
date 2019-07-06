using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace CustomDepenProp
{
    class SMStackPanel : StackPanel
    {

        public static DependencyProperty IsBrownBackgrndProperty = DependencyProperty.Register("IsBrownBackgrnd",typeof(bool),typeof(SMStackPanel),
            new PropertyMetadata(false,OnIsBrownBackgrndChanged, CoerceIsBrownChanged));

        private static object CoerceIsBrownChanged(DependencyObject d, object baseValue)
        {
            SMStackPanel smstack = d as SMStackPanel;

            if (smstack.IsBrownBackgrnd == false)
            {
             //   MessageBox.Show("The dependency prop is being changed to true");
                return true;
            }
            else
            {
             //   MessageBox.Show("The dependency prop is being changed to false");
                return false;
            }

        }

        public bool IsBrownBackgrnd
        {
            get { return (bool)GetValue(IsBrownBackgrndProperty);}

            set { SetValue(IsBrownBackgrndProperty, value); }
        }

        private static void OnIsBrownBackgrndChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            SMStackPanel smsp = source as SMStackPanel;
            if (smsp.IsBrownBackgrnd == true)
            {
                smsp.Background = System.Windows.Media.Brushes.BurlyWood;
            }
            else
            {
                smsp.Background = System.Windows.Media.Brushes.CadetBlue;
            }
        }
    }
}
