using System.Windows;
using System;
using System.Windows.Threading;
using WPF.Sample.ViewModelLayer;


namespace WPF.Sample
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel = null;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = (MainWindowViewModel) this.Resources["viewModel"];
        }



        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Dispatcher.BeginInvoke(new Action(() =>
            {
                System.Threading.Thread.Sleep(2000);
                _viewModel.IsInfoMessageVisible = false;
                ClearInfoMessages();
            }), DispatcherPriority.Background);

        }

        
        private void ClearInfoMessages()
        {
          _viewModel.IsInfoMessageVisible = false;
            _viewModel.InfoMessage = "";
            _viewModel.InfoMessageTitle="";
        }

    }
}


