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

namespace EntityDataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ZzaDbContext _DbContext = new ZzaDbContext();

        public MainWindow()
        {
            
            InitializeComponent();

            Customers = _DbContext.Customers.ToList();
            CustomersCombo.SelectedItem =Customers[0];
            DataContext = this;


        }

        public List<Customer> Customers {get; set;}
        public Customer SelectedCustomer {get; set;}
         
        private void OnCustomerSelected(object sender, SelectionChangedEventArgs e)
        {
            SelectedCustomer = CustomersCombo.SelectedItem as Customer;

        }

        private void OnAdd(object sender, RoutedEventArgs e)
        {

        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {

        }

    }
}
