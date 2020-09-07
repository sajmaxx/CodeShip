using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace WPFApp3ToolKit
{
    class MainWindowViewModel
    {
        string _contentA = "tora bora";
        string _contentB =  "coca cola";


        public string ContentA
        {
            get => _contentA;
            set => _contentA = value;
        }

        public string ContentB
        {
            get => _contentB;
            set => _contentB = value;
        }

        public ICommand CommandA
        {
            get => commandA;
            set => commandA = value;
        }

        public ICommand CommandB
        {
            get => commandB;
            set => commandB = value;
        }


        ICommand commandA, commandB;

        public MainWindowViewModel()
        {
            ContentA = "fantastico";

            CommandA = new RelayCommand(DoSomeStuf, CanExcucuteDoSomeStuff);

            CommandB = new RelayCommand(DoSomeMoreExtraStuff, CanExcucuteDoSomeStuff);
            
        }

        private void DoSomeStuf()
        {
            MessageBox.Show("La La land");
        }


        private void DoSomeMoreExtraStuff()
        {
            Thread.Sleep(2000);
            MessageBox.Show("What a guy what a job");
        }

        private bool CanExcucuteDoSomeStuff()
        {
            return true;
        }


    }
}
