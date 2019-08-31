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

namespace UserControlDepProp
{
    /// <summary>
    /// Interaction logic for SUserCon.xaml
    /// </summary>
    public partial class SUserCon : UserControl
    {
        public SUserCon()
        {
            InitializeComponent();
        }



        public double StockValue
        {
            get { return (double)GetValue(StockValueProperty); }
            set { SetValue(StockValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StockValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StockValueProperty =
            DependencyProperty.Register("StockValue", typeof(double), typeof(SUserCon), new PropertyMetadata(200.000));


    }
}
