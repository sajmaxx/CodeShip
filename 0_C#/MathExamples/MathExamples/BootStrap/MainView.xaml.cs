using System.Windows;
using MathExamples.BootStrap;

namespace MathExamples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel theviewmodel = new MainViewModel();
            this.DataContext = theviewmodel;
            var aa = 330;
            aa  += 330;
            var aaa  = 330;
            aaa = 44 + aaa;


        }
    }
}
