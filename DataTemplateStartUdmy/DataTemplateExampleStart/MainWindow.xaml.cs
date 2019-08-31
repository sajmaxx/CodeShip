using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DataTemplateExampleStart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SampleData sdata = new SampleData();


        public MainWindow()
        {
            InitializeComponent(); this.DataContext = this;
            // Add this line to the Window element instead of this.DataContext here...
            // DataContext="{Binding RelativeSource={RelativeSource Self}}" 
            
        }

        public ObservableCollection<Employee> Employees { get { return sdata.EmployeeList; } }

        
        
    }
}
