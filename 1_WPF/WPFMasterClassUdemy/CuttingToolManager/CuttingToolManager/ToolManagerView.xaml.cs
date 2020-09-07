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
using CuttingToolManager.Models;
using CuttingToolManager.Views;

namespace CuttingToolManager
{
    /// <summary>
    /// Interaction logic for ToolManagerView.xaml
    /// </summary>
    public partial class ToolManagerView : Window
    {

        public ToolManagerView()
        {
            InitializeComponent();
            ReadDataBase();
        }

        private void createToolButton_Click(object sender, RoutedEventArgs e)
        {
            ToolAddView locToolAddView = new ToolAddView();
            locToolAddView.ShowDialog();
            ReadDataBase();
        }

        void ReadDataBase()
        {

            using(SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DatabasePath))
            {

                conn.CreateTable<CuttingTool>();
                var tools = conn.Table<CuttingTool>(); //this is a query of type  CuttingTool
                App.toolList  = tools.ToList<CuttingTool>();
            }

            if (App.toolList != null)
            {
               // OldFashionedWayToLinkContent();
              toolListView.ItemsSource = App.toolList;
            }
            
        }

        private void OldFashionedWayToLinkContent()
        {
            foreach (var tool in App.toolList)
            {
                toolListView.Items.Add(new ListViewItem()
                {
                    Content = tool
                });

            }
        }
    }
}
