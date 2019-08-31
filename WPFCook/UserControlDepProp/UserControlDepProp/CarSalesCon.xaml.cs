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
    /// Interaction logic for CarSalesCon.xaml
    /// </summary>
    public partial class CarSalesCon : UserControl
    {
        public CarSalesCon()
        {
            InitializeComponent();


        }



        public string BrandName
        {
            get { return (string)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("BrandName", typeof(string), typeof(CarSalesCon), new PropertyMetadata("NoName"));


    }
}
