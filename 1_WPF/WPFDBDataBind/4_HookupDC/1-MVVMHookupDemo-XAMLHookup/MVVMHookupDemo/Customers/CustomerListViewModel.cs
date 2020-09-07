using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMHookupDemo.Services;
using Zza.Data;

namespace MVVMHookupDemo.Customers
{
    public class CustomerListViewModel
    {
        private ICustomersRepository _cusRepo = new CustomersRepository();
        public ObservableCollection<Customer>Customers { get; set; }

        public CustomerListViewModel()
        {
            if(DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;
            Customers = new ObservableCollection<Customer>(_cusRepo.GetCustomersAsync().Result);
            
        }
    }
}
