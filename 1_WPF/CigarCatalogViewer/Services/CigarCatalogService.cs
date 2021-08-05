using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CigarCatalogViewer.Model;
using LiteDB;

namespace CigarCatalogViewer.Services
{
    public class CigarCatalogService : ICigarCatalogService
    {
        private string LiteDBPath = @"c:\Temp\Cigar2021D.db";
        private LiteDatabase CigarLiteDB;

        public CigarCatalogService()
        {
            FillDBwithPreviousData();
        }


        private void FillDBwithPreviousData()
        {
            
            using (CigarLiteDB = new LiteDatabase(LiteDBPath))
            {
                var dbList = CigarLiteDB.GetCollection<Cigar>("cigars2020");
                var counter = dbList.Count();
                if (counter == 0)
                {
                    Cigar locCigar = new Cigar
                    {
                        Id = 11,
                        Company = "My Father",
                        Name = "Espinoza Especial",
                        Price = 15.00,
                        Rating = 90
                    };

                    dbList.Insert(locCigar);


                    locCigar = new Cigar()
                    {
                        Id = 12,
                        Company = "Artos Fuente",
                        Name = "Dynamite",
                        Price = 10.00,
                        Rating = 95
                    };
                    dbList.Insert(locCigar);



                    locCigar = new Cigar()
                    {
                        Id = 13,
                        Company = "Arturo Fuente",
                        Name = "Dynamite",
                        Price = 10.00,
                        Rating = 95
                    };
                    dbList.Insert(locCigar);


                    locCigar = new Cigar()
                    {
                        Id = 14,
                        Company = "Oliva",
                        Name = "Series V",
                        Price = 10.00,
                        Rating = 95
                    };
                    dbList.Insert(locCigar);


                    locCigar = new Cigar()
                    {
                        Id = 15,
                        Company = "Oliva",
                        Name = "Series O",
                        Price = 10.00,
                        Rating = 95
                    };
                    dbList.Insert(locCigar);

                    locCigar = new Cigar()
                    {
                        Id = 16,
                        Company = "A.J. Fernandez ",
                        Name = "Tabernacle",
                        Price = 10.00,
                        Rating = 95
                    };
                    dbList.Insert(locCigar);

                    locCigar = new Cigar()
                    {
                        Id = 17,
                        Company = "Drew Estate",
                        Name = "Crazy Alice",
                        Price = 10.00,
                        Rating = 95
                    };
                    dbList.Insert(locCigar);


                    locCigar = new Cigar()
                    {
                        Id = 18,
                        Company = "H. Upmann",
                        Name = "Hispanola",
                        Price = 10.00,
                        Rating = 95
                    };
                    dbList.Insert(locCigar);

                    locCigar = new Cigar()
                    {
                        Id = 19,
                        Company = "A.J. Fernandez ",
                        Name = "Aging Room 101",
                        Price = 10.00,
                        Rating = 95
                    };
                    dbList.Insert(locCigar);
                }

            }


        }

        public void UpdateDataForCigar(Cigar aCigar)
        {

            var cigarList = CigarLiteDB.GetCollection<Cigar>("cigars");
            if (cigarList.Count() > 0)
            {
                cigarList.Update(aCigar);
            }

        }

        public void DeleteCigarFromDB(Cigar aCigar)
        {
            var cigarList = CigarLiteDB.GetCollection<Cigar>("cigars");
        }


        public List<Cigar> GetBackListofCigars()
        {
            using (CigarLiteDB = new LiteDatabase(LiteDBPath))
            {
                var cigLiteList = CigarLiteDB.GetCollection<Cigar>("cigars2020");
            
                //List<Cigar> ListofCigars = new List<Cigar>();

                var counter = cigLiteList.Count();
                var ListofCigars =  cigLiteList.Query().ToList();
                return ListofCigars;
            }
        }

    }
}
