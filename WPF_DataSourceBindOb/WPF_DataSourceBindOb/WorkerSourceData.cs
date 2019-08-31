using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WPF_DataSourceBindOb
{
    public class WorkerSourceData
    {

        public ObservableCollection<WorkerMan> WorkerManList = new ObservableCollection<WorkerMan>();


        public WorkerSourceData()
        {
            WorkerManList.Add(new WorkerMan("sasha",45,433));
            WorkerManList.Add(new WorkerMan("Tasha",35,1654));
            WorkerManList.Add(new WorkerMan("Rasha",25,327));
            WorkerManList.Add(new WorkerMan("Masha",35,259));

        }
    }
}
