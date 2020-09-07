using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CigarShop.Annotations;

namespace CigarShop.Models
{
    public class Cigar : INotifyPropertyChanged
    {
        string _company;
        string _name;
        int _yearMfg;

        public event PropertyChangedEventHandler PropertyChanged;


        public string Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged("Company");
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");

            }
        }

        public int YearOfMfg
        {
            get => _yearMfg;
            set
            {
                _yearMfg = value;
                OnPropertyChanged("YearOfMfg");
            }
        }

        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public Cigar(string company, string name, int yearMfg)
        {
            _company = company;
            _name = name;
            _yearMfg = yearMfg;
        }
        
    }
}

