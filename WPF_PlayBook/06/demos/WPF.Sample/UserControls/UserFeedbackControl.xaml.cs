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
using WPF.Sample.ViewModelLayer;

namespace WPF.Sample.UserControls
{
  /// <summary>
  /// Interaction logic for UserFeedbackControl.xaml
  /// </summary>
  public partial class UserFeedbackControl : UserControl
  {
    public UserFeedbackControl()
    {
      InitializeComponent();

      // Connect to instance of the view model created by the XAML
      _viewModel = (UserFeedbackViewModel)this.Resources["viewModel"];
    }

    private UserFeedbackViewModel _viewModel = null;

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Close(true);
    }
  }
}
