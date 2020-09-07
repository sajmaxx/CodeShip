using GalaSoft.MvvmLight.CommandWpf;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace WPFApp4MVVM.BootStrap
{
    class MainWindowViewModel
    {

        private string button1txt;
        private string button2txt;
        private string button3txt;

        public string Button1Txt
        {
            get => button1txt;
            set => button1txt = value;
        }

        public string Button2Txt
        {
            get => button2txt;
            set => button2txt = value;
        }

        public string Button3Txt
        {
            get => button3txt;
            set => button3txt = value;
        }

        public ICommand CommandA
        {
            get => _commandA;
            set => _commandA = value;
        }

        public ICommand CommandB
        {
            get => _commandB;
            set => _commandB = value;
        }

        public ICommand CommandC
        {
            get => _commandC;
            set => _commandC = value;
        }


        private ICommand _commandA, _commandB, _commandC;


        public MainWindowViewModel()
        {
            button1txt = "Alpha";
            button2txt = "Beta";
            button3txt = "Gamma";

            CommandA = new RelayCommand(ActionA, ActionHappened);
            CommandB = new RelayCommand(ActionB, ActionHappened);
            CommandC = new RelayCommand(ActionC, ActionHappened);


        }


        private void ActionA()
        {
            MessageBox.Show("This is A Action");
        }


        private void ActionB()
        {
            Thread.Sleep(3000);
            MessageBox.Show("This is B Action");
        }


        private void ActionC()
        {
            Thread.Sleep(4000);
            MessageBox.Show("Class action C");
        }

        private bool ActionHappened()
        {
            return true;
        }

    }

}
