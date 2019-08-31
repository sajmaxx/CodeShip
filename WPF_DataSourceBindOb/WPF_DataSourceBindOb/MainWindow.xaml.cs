namespace WPF_DataSourceBindOb
{
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

    /// <summary>
    /// Interaction logic for MainWindow
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly WorkerSourceData workSourceList;

        /// <summary>
        /// Constructor Default
        /// </summary>
        public MainWindow()
        {
            workSourceList = new WorkerSourceData();
            this.DataContext = this;
            InitializeComponent();
        }

        public ObservableCollection<WorkerMan> WorkerSourceData {
            get { return workSourceList.WorkerManList;} 
        }
    }
}
