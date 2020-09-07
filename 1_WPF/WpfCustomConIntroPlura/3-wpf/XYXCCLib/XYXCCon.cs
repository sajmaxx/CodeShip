using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XYXCCLib
{
    public class XYXCCon : Control
    {
        static XYXCCon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(XYXCCon), new FrameworkPropertyMetadata(typeof(XYXCCon)));
        }

        public static readonly DependencyProperty LandTitleProperty = DependencyProperty.Register("LandTitle", typeof(string), typeof  (XYXCCon), 
          new FrameworkPropertyMetadata("alma mater is default", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnTextPropertyChanged), new CoerceValueCallback(OnTextPropertyCoerce)) );

        //helps you to change the incoming value!!!
        private static object OnTextPropertyCoerce(DependencyObject d, object baseValue)
        {
            string stringa = baseValue as string;
            if (stringa.Length > 10)
                return "booo yeah";
            else
                return baseValue;

            
        }

        private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           XYXCCon control = d as XYXCCon;
            //e.NewValue  e.OldValue

            if (control != null)
            {
                control.DoWorkOnChange((string)e.OldValue, (string)e.NewValue);
            }
        }

        private void DoWorkOnChange(string old, string newa)
        {
            var baba = old + newa;
        }

        public string LandTitle //Wrapper Property for DP
        {
            get { return (string)GetValue(LandTitleProperty);}
            set { SetValue(LandTitleProperty, value);}
        }
    }
}
