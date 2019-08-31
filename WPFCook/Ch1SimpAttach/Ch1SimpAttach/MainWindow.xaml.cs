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

namespace Ch1SimpAttach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int deltaval = 5;
        double rota = 4;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(_rect, Canvas.GetLeft(_rect) + deltaval);
            if ((Canvas.GetLeft(_rect) + deltaval) > 400)
            {
                deltaval = -5;
            }

            if ((Canvas.GetLeft(_rect) + deltaval) <= 10)
            {
                deltaval = - deltaval;
            }

        }

        private void RotateButt_Click(object sender, RoutedEventArgs e)
        {
            RotationManager.SetAngle(_rect,rota);
            rota += 5.0;
        }

        private void ScrewMove_Click(object sender, RoutedEventArgs e)
        {
            RotateButt_Click(sender, e);
            RepeatButton_Click(sender,  e);
        }
    }
}
