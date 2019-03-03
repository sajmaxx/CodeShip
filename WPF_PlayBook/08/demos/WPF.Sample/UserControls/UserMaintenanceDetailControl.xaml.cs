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
  /// Interaction logic for UserMaintenanceDetailControl.xaml
  /// </summary>
  public partial class UserMaintenanceDetailControl : UserControl
  {
    public UserMaintenanceDetailControl()
    {
      InitializeComponent();
    }

    private UserMaintenanceViewModel _viewModel;

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
      _viewModel = (UserMaintenanceViewModel)this.DataContext;
    }

    private void UndoButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.CancelEdit();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Save();
    }
  }
}
