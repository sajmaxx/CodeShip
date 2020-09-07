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

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            
            //demo purposes only, check for previous instances and remove handler first
            var button = GetTemplateChild("PART_Button") as Button;
            if (button != null)
                button.Click += Button_Click;

        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
         
            RaiseSaMouseClickEvent();
        }


        public static readonly RoutedEvent SaMouseClickEvent 
        = EventManager.RegisterRoutedEvent(" SaMouseClick", RoutingStrategy.Bubble, typeof(MyRoutedEventHandler), typeof(MyCustomControl));

        public event MyRoutedEventHandler SaMouseClick
        {
           add { AddHandler(SaMouseClickEvent, value);}
           remove { RemoveHandler(SaMouseClickEvent, value); }
        }


        protected virtual void RaiseSaMouseClickEvent()
        {
            MyRoutedEventArgs args = new MyRoutedEventArgs(MyCustomControl.SaMouseClickEvent, "sajaaaa");
            RaiseEvent(args);
        }
    }

    public delegate void MyRoutedEventHandler(object sender, MyRoutedEventArgs e);

    public class MyRoutedEventArgs : RoutedEventArgs
    {
        public string Paramble { get; set;}

        public MyRoutedEventArgs(RoutedEvent revent, string param1)
         : base(revent)
        {
            Paramble = param1;       
        }
    }
}
