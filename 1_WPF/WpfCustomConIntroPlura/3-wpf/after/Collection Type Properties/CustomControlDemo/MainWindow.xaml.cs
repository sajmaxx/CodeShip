using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CustomControlDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataObject obj1 = new DataObject();
            DataObject obj2 = new DataObject();

            _list1.Items.Add(obj1);
            _list2.Items.Add(obj2);
        }

        public class DataObject : INotifyPropertyChanged
        {
            private String _name;
            public String Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected void NotifyPropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
