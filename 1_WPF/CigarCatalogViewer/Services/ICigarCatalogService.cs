using System.Collections.Generic;
using CigarCatalogViewer.Model;

namespace CigarCatalogViewer.Services
{
    public interface ICigarCatalogService
    {
         void UpdateDataForCigar(Cigar aCigar);
         void DeleteCigarFromDB(Cigar aCigar);
         List<Cigar> GetBackListofCigars();

    }
}