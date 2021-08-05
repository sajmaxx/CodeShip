using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CigarCatalogViewer.Model;
using CigarCatalogViewer.Services;

namespace CigarCatalogViewer
{
    public class MainWindowViewModel
    {
        private CigarCatalogService CigarService;

        public ObservableCollection<Cigar> Cigars { get; set; }

        public MainWindowViewModel()
        {
            CigarService = new CigarCatalogService();
            var CigarViewList = CigarService.GetBackListofCigars();

            Cigars = new ObservableCollection<Cigar>();
            foreach (var cig in CigarViewList)
            {
                Cigars.Add(cig);
            }

        }

    }
}
