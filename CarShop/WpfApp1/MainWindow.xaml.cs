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
using CarShop.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private void SetupforStart()
        {
           CarLots.LoadFromDB();    
        }

        private FibonacciSeq someFib;
        public MainWindow()
        {
            InitializeComponent();
            SetupforStart();
           someFib = new FibonacciSeq(10);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // CarLB.ItemsSource = CarLots.GetMyCars();



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            IEnumerable<Car> mycarlist = CarLots.GetMyCars();

            foreach (Car caro in mycarlist)
            {
                CarLB.Items.Add(caro);
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            if (someFib.StartIndex == null)
            {
                someFib.StartIndex = !someFib.StartIndex.HasValue ? 2 : 3;

                
                someFib.StartStatus = !someFib.StartStatus.HasValue ? true : false;


                if (! someFib.CurrentNum.HasValue)
                  someFib.CurrentNum = 333;


                foreach (var item in someFib)
                    Fibolist.Items.Add(item);
            }
            else
            {


                int gettheCurrentNum = someFib.CurrentNum.HasValue ? 444 : 50000;

                foreach (var item in someFib)
                    Fibolist.Items.Add(item);

                someFib.CurrentNum = null;
                
            }
        }
    }
}
