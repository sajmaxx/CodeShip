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
            RaiseClickEvent();
        }

        public static readonly RoutedEvent ClickEvent =
            EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(MyCustomControl));

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        protected virtual void RaiseClickEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(MyCustomControl.ClickEvent);
            RaiseEvent(args);
        }
    }
}
