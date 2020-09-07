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
using DesktopContactsApp.Classes;

namespace DesktopContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for Cust20Control.xaml
    /// </summary>
    public partial class Cust20Control : UserControl
    {



        public Contact Contact
        {
            get { return (Contact)GetValue(ContactPropProperty); }
            set { SetValue(ContactPropProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContactProp.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactPropProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(Cust20Control), new PropertyMetadata(new Contact(){Name="sasha", Phone="53255343", Email="gaga@google.com"}, Settext));

        private static void Settext(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Cust20Control control = d as Cust20Control;
            if (control != null)
            {
                control.nameTextBlock.Text =  (e.NewValue as Contact).Name;
                control.emailTextBlock.Text = (e.NewValue as Contact).Email;
                control.phoneTextBlock.Text = (e.NewValue as Contact).Phone;
            }
        }


        public Cust20Control()
        {
            InitializeComponent();
        }
    }
}
