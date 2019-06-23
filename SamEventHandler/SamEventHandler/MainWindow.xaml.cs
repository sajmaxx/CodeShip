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

namespace SamEventHandler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WorkerBee babee = new WorkerBee(400, 400);
            babee.OnAchievingWork += MahbeeListener;
            babee.OnJajaBoink += jajajListener;
            babee.DothaWork();
        }



        static void jajajListener(object sender, EventArgs e)
        {
            Console.WriteLine(" baba jajaja");
        }

        static void  MahbeeListener(object sender, SpecialWorkEventArgs e)
        {
            Console.WriteLine(" THE EVENT LISTENER CAUGHT SOMETHING! WE GOT WORK! ", e.Work );
        
        }

    }
}
