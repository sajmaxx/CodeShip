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
    public class MyCustomControl : Control
    {
        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        }

        public MyCustomControl()
        {

        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MyCustomControl),
            new FrameworkPropertyMetadata("Default", 
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                new PropertyChangedCallback(OnTextPropertyChanged),
                new CoerceValueCallback(OnTextPropertyCoerce)));
        
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private static object OnTextPropertyCoerce(DependencyObject d, object baseValue)
        {
            //your logic here
            return baseValue;
        }

        private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MyCustomControl control = d as MyCustomControl;
            if (control != null)
                control.OnTextPropertyChanged((string)e.OldValue, (string)e.NewValue);
        }

        protected virtual void OnTextPropertyChanged(string oldValue, string newValue)
        {
            //property changed logic here
        }


    }
}
