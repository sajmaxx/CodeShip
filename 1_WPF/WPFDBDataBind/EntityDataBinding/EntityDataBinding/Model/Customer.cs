using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataBinding
{
    public class Customer : INotifyPropertyChanged
    {

        private  Guid _Id;
        private string _FirstName; 
        private string _LastName; 
        private string _Email;
        private List<Order> _Orders; 

        
        public event PropertyChangedEventHandler PropertyChanged = delegate { };



        public Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }

        }

        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
                PropertyChanged(this, new PropertyChangedEventArgs("FullName"));
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
                PropertyChanged(this, new PropertyChangedEventArgs("FullName"));
            } 

        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        public List<Order> Orders
        {
            get
            {
                return _Orders;
            }
            set
            {
                _Orders = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Orders") );
            }
        }

        public string FullName 
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}
