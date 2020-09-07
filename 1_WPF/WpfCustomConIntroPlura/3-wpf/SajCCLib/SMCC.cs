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

namespace SajCCLib
{

    public class SMCC : Control
    {
        static SMCC()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SMCC), new FrameworkPropertyMetadata(typeof(SMCC)));
        }

        public static readonly DependencyProperty SMStreetProperty = DependencyProperty.Register("SMStreet", typeof(int), typeof(SMCC),
            new FrameworkPropertyMetadata( 10, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public int SMStreet
        {
            get { return (int)GetValue(SMStreetProperty); }
            set { SetValue(SMStreetProperty, value);}
        }


        public static readonly DependencyProperty SMCarNameProperty = DependencyProperty.Register("SMCarName", typeof(string), typeof(SMCC),
            new FrameworkPropertyMetadata("Oho its a default", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string SMCarName
        {
            get { return (string)GetValue(SMCarNameProperty);}
            set {  SetValue(SMCarNameProperty, value);}
        }


    }
}
