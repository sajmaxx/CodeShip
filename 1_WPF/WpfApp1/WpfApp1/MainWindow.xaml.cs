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
using DataBinding101.MathLib2020;
using DataBinding101.StrLib2020;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<double> salesbyMonth = new List<double>();

            salesbyMonth.Add(540000);
            salesbyMonth.Add(50000);
            salesbyMonth.Add(1054000);
            salesbyMonth.Add(1004300);
            salesbyMonth.Add(10434000);
            salesbyMonth.Add(130000);
            salesbyMonth.Add(1333430);
            salesbyMonth.Add(3410000);

            var medianval = salesbyMonth.Median();
            var trimmedav = salesbyMonth.TruncatedMean(2);
            MessageBox.Show("The truncated mean is this " + trimmedav);

            string thisvalue = trimmedav.ToString() + "alpha";

            string encrypted = thisvalue.Encrypt();

            MessageBox.Show(encrypted);

            MessageBox.Show(encrypted.Reverser());

        }
    }
}
