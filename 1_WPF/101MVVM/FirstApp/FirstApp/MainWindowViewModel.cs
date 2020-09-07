using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.CommandWpf;

namespace FirstApp
{
    class MainWindowViewModel
    {

        public string ButtonContent1
        {
            get => "Hola bola";
        }

        public string ButtonContent2
        {
            get => "vola bola";
        }


        public ICommand firstButtonCommand;
        public ICommand secButtonCommand;

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            private set => _isBusy = value;
        }

        public ICommand FirstButtonCommand
        {
            get => firstButtonCommand;
            set => firstButtonCommand = value;
        }

        private void ExecuteSubmit()
        {
            IsBusy = true;
            MessageBox.Show("Do some thing with respect");
            IsBusy = false;
        }

        private bool CanExecuteSubmit()
        {
            return true;
        }


        public MainWindowViewModel()
        {
            FirstButtonCommand   = new RelayCommand(ExecuteSubmit, CanExecuteSubmit);
        }


    }
}
