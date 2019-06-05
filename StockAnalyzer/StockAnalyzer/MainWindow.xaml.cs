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
using  StockAnalyzer.ViewModels;
using StockAnalyzer.Models;

namespace StockAnalyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartBusinessVM.StartMarket();
        }

        private void ChangeTheTrade(ref ITradeData someTrade)
        {
            someTrade = new StockData(33);
        }

        private void MakeMyListofInts()
        {
            List<int> IdList = new List<int>();

            IdList.Add(33);
            IdList.Add(44);
            IdList.Add(45);
            IdList.Add(34);
            IdList.Add(32);
            IdList.Add(52);
            IdList.Add(62);
            IdList.Add(82);


            IdList.Remove(32);


           
            IdList.RemoveAll(x => (x > 35) && (x < 56) );



             List<string> NameList = new List<string>
             {
                 "Mon"  , " Tue", "Fri"
             };

        }


        private void MakeBioDictionary()
        {
            Dictionary<string, int> BioDic = new Dictionary<string, int>();

            
            BioDic.Add("saj",33);
            BioDic.Add("raj",43);
            BioDic.Add("taj",53);
            BioDic.Add("taj2",63);
            BioDic.Add("taj3",93);
            BioDic.Add("taj4",103);

            
            var Mahvalue = BioDic["raj"];

           Mahvalue = Mahvalue + 100;

           BioDic.Add("James",52);


           int ageis; 
           BioDic.TryGetValue("saj", out ageis);



           foreach (int age in BioDic.Values)
           {
               Console.WriteLine("Age is " + age.ToString());
           }

           foreach (var nameagpair in BioDic)
           {
               if (nameagpair.Key == "saj")
               {
                   MessageBox.Show("My Nam is " + nameagpair.Key);
                   break;
               }
           }

        }

 

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            MakeMyListofInts();
            MakeBioDictionary();
            
            StartBusinessVM.ForceMarketOpen();

            ITradeMarket someTrade = StartBusinessVM.ChooseMarket(1);

            StockData BOE  = new StockData(1);

            if (someTrade is NYSMarket)
            {
                var saleprice = BOE.MarketPrice??200;
                var marketrate = BOE.PurchasedPrice??200;
                   
                someTrade.Buy((ITradeData)BOE);

                ITradeData itrade = (ITradeData)BOE;
               ChangeTheTrade(ref itrade);

               BOE.MarketPrice = BOE.MarketPrice??300;
               BOE.PurchasedPrice = BOE.PurchasedPrice??400;

               MakeMyListofInts();

            }

        }

        private void ButtonCalc_Click(object sender, RoutedEventArgs e)
        {
            List<int> IdList = new List<int>();

            IdList.Add(33);
            IdList.Add(44);
            IdList.Add(45);
            IdList.Add(34);
            IdList.Add(32);
            IdList.Add(52);
            IdList.Add(62);
            IdList.Add(82);


            IdList.Remove(32);

            foreach (var val in IdList.Take(8).Where(x => x <= 66))
            {
                Console.WriteLine("Idlist member is " + val.ToString());
            }

            var DesFilter = IdList.Where(x => ((x > 33) &&(x <77))).Take(5);


            Console.WriteLine("LINQ QUery Statement");


            foreach (var malue in DesFilter)
            {
                Console.WriteLine("LINQ FIlterList {0}", malue);
            }

        }
    }
}
