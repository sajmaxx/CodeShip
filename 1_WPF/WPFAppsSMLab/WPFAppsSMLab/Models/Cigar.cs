using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;

namespace WPFAppsSMLab.Models
{
    public class Cigar  : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyRaised("Name");
                OnPropertyRaised("CatalogName");
            }
        }
        

        private string _mfg;

        public string Mfg
        {
            get => _mfg;
            set
            {
                _mfg = value;
                OnPropertyRaised("Mfg");
                OnPropertyRaised("CatalogName");
            }
        }

        private string _catalogName;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised(string propName)
        {
            PropertyChanged?.Invoke(this,  new PropertyChangedEventArgs(propName));
            
        }

        public string CatalogName
        {
            get => Name + " " + Mfg;
            set
            {
                _catalogName = value;
                OnPropertyRaised("CatalogName");
            }
        }

        public Cigar()
        {
            Name = "AgingRoom";
            Mfg = "AJH";
        }
    }
}
