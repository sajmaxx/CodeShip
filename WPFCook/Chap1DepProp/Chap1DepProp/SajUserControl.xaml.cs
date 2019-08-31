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

namespace Chap1DepProp
{
    /// <summary>
    /// Interaction logic for SajUserControl.xaml
    /// </summary>
    public partial class SajUserControl : UserControl
    {
        public SajUserControl()
        {
            InitializeComponent();
        }



        public int YearofBools
        {
            get { return (int)GetValue(YearofBoolsProperty); }
            set { SetValue(YearofBoolsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for YearofBools.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YearofBoolsProperty =
            DependencyProperty.Register("YearofBools", typeof(int), typeof(SajUserControl), new PropertyMetadata(2040));


    }
}
