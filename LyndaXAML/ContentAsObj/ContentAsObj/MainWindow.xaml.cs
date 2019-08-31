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

namespace ContentAsObj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //ASSIGNING DIFFERENT KINDS OF OBJECTS as Contents to Buttons

            button1.Content = "hello mars";


            var flowerimage = new Image();
            flowerimage.Source = new BitmapImage( new Uri("Images/flower.jpg", UriKind.Relative));
            button2.Content = flowerimage;


            button3.Content = new Models.TouristMan
            {
                Description = "Israel visit 2020",
                MultiDay = false,
                TourId = 777,
                TourName = "Visit to Jerusalem"
            };

        }
    }
}
