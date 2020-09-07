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
using CigarShop.Models;

namespace CigarShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cigar _backupCigar;
        Cigar _activeCigar = new Cigar("Punch","Reserva2020", 1993);
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _activeCigar;
        }

        public Cigar ActiveCigar
        {
            get => _activeCigar;
            set => _activeCigar = value;
        }

        private void GetNewCigar_Click(object sender, RoutedEventArgs e)
        {
            _backupCigar = new Cigar("Plasencia","Turbinado Oscuro", 1983);
            this.DataContext = _backupCigar;
        }
    }
}
