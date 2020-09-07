using CustomControlLib;
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

            //Demo purposes only
            //due to how this demo was implemented this code runs after the OnInitialezed
            //of our custom control. Meaning this won;t accurately update the ChildCount value.
            _stackPanel.SetValue(MyCustomControl.IncludeChildCountProperty, true);
            MyCustomControl.SetIncludeChildCount(_stackPanel, true);
        }
    }
}
