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
using  WorkwithNulls.Models;

namespace WorkwithNulls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Customer SampleCust =  null; //new Customer();

            



            ///NULL CONDITIONAL  OPERATOR
            int agesofages =  SampleCust?.Age ?? 400;
            SampleCust = new Customer();

            SampleCust.Clubystrat = new  GoldClub();

            int mothman = SampleCust?.Age ?? 400;
            SampleCust.Age = 33;

            int rothman = SampleCust?.Age ?? 400000;



            var toto = SampleCust.Age.GetValueOrDefault(33);


            /// NULL COALESCING OPERATOR
            var fofo = SampleCust.Age ?? 40000;
            SampleCust.Age = 444;
            var tofo = SampleCust.Age ?? 7770;


            ///CONDITIONAL OPERATOR EXAMPLE   () ? () : ()
            var toto2 = SampleCust.Age.HasValue ? SampleCust.Age.Value : 77;
            var toto4 = (SampleCust.Age > 300) ? toto2  : SampleCust.Age.Value;
            int baba = 466;
            int data = 3;
            double valueis = (baba*data > 18200) ? 44.55 : 55.879;
            double momo = ((baba+data+valueis) > 4400) ? 664.33 : 14000;


            Customer [] custoArry = new Customer[3]
            {
                new Customer { Age  = 33},
                new Customer(),
                null
            };


            custoArry[0].Clubystrat = new  PlatinumClub();

            int? firstva = custoArry?[0]?.Age;
            int? seconva = custoArry?[1]?.Age;
            int? thirdva =  custoArry?[2]?.Age;

            


            //NULL COALESCING OPERATOR

            if (SampleCust.Age.HasValue)
            {
                
                MessageBox.Show("Age of customer is " + SampleCust.Age.ToString());
                

            }
            else
            {
                MessageBox.Show("Customer Has no Age Set " + SampleCust.Age.ToString());
                
            }
        }
    }
}
