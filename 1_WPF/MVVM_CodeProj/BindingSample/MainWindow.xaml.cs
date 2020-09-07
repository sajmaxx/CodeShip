using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BindingSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentData _studentData = new StudentData { StudentFirstName = "John", StudentGradePointAverage = 3.5};

        StudentData _studentData2 = new StudentData { StudentFirstName = "Saul", StudentGradePointAverage = 2.5};

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = _studentData;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = _studentData2;
        }
    }
}
