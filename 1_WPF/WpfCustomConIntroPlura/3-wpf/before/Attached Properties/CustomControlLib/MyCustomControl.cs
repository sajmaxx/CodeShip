using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomControlLib
{
    public class MyCustomControl : ContentControl
    {
        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        }

        public static readonly DependencyProperty ChildCountProperty =
            DependencyProperty.Register("ChildCount", typeof(int), typeof(MyCustomControl), new PropertyMetadata(0));

        public int ChildCount
        {
            get { return (int)GetValue(ChildCountProperty); }
            set { SetValue(ChildCountProperty, value); }
        }
    }
}
