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
using ContactAppSQLLite2.Models;
using SQLite;

namespace ContactAppSQLLite2.Views
{
    /// <summary>
    /// Interaction logic for AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        public AddContactWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Contact myContact = new Contact()
            {
                Name = nameTextbx.Text,
                Email = emailTextbx.Text,
                Phone = phoneTextbx.Text
            };


            //Save to DataBase
            using (SQLiteConnection appConnection = new SQLiteConnection(App.databasePath))
            {
                appConnection.CreateTable<Contact>(); // will not create if table is already existing.
                appConnection.Insert(myContact);
            }

            Close();
        }
    }
}
