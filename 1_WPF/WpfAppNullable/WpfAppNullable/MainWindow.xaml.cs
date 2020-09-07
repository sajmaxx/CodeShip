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

namespace WpfAppNullable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
         
            InitializeComponent();

            PlayerChara someplaya = new PlayerChara();

            if (string.IsNullOrEmpty(someplaya.Name))
            {
                someplaya.Name = "sasha";
            }

            if (someplaya.DaysSinceLastLogin.HasValue)
            {
                MessageBox.Show($"Days Since last login"  + someplaya.DaysSinceLastLogin.ToString());

            }
            else
            {
                MessageBox.Show("Days Since Last Login Undefined");
            }
             
            int? nulli  = 44;
            int justi = 44;

            bool meow = nulli == justi;

            nulli = justi;


            //null Checking Operators
            //First Operator Conditional Operator  ?:
            /// Conditional Operator ? :
            ///  Conditional Operator ? :
            ///
            /// Null-Coalescing Operator
            /// ??
            /// Null-Coalescing Operator
            /// ??
            /// Null-Condtional Operator
            ///  ?. ?[
            /// ?. ?[
            ///
            



        }
    }
}
