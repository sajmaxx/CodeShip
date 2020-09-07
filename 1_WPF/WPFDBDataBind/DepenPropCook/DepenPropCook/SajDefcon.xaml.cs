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

namespace DepenPropCook
{
    /// <summary>
    /// Interaction logic for SajDefcon.xaml
    /// </summary>
    public partial class SajDefcon : UserControl
    {
        public SajDefcon()
        {
            InitializeComponent();
        }



        public double NetProfitAmount
        {
            get { return (double)GetValue(NetProfitAmountProperty); }
            set { SetValue(NetProfitAmountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NetProfitAmount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NetProfitAmountProperty =
            DependencyProperty.Register("NetProfitAmount", typeof(double), typeof(SajDefcon), new PropertyMetadata(777.77));

            
    }
}
