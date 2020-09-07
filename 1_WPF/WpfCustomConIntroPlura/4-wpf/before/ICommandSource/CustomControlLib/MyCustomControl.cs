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
        private Border _border;

        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (_border != null)
                _border.MouseLeftButtonUp -= Border_MouseLeftButtonUp;
            _border = GetTemplateChild("PART_Border") as Border;
            if (_border != null)
                _border.MouseLeftButtonUp += Border_MouseLeftButtonUp;
        }

        void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
