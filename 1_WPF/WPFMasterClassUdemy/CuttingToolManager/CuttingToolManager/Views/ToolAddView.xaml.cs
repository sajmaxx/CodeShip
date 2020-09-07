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
using System.Windows.Shapes;
using CuttingToolManager.Models;
using SQLite;

namespace CuttingToolManager.Views
{
    /// <summary>
    /// Interaction logic for ToolAddView.xaml
    /// </summary>
    public partial class ToolAddView : Window
    {
        public ToolAddView()
        {
            InitializeComponent();
        }

        private void AddToolEventClick(object sender, RoutedEventArgs e)
        {

            //Create the tool
            CuttingTool SomeTool = new CuttingTool()
            {
                ToolName = toolNameTextBx.Text,
                ToolDiameter = double.Parse(tooldiaTextBx.Text),
                ToolType = toolfuncTextBx.Text
            };


            // initialize to connect to db

            using (SQLiteConnection tooldbConnection = new SQLiteConnection(App.DatabasePath))
            {
                tooldbConnection.CreateTable<CuttingTool>();
                tooldbConnection.Insert(SomeTool);
            };
            // make connection and write to db

            Close();

        }
    }
}
