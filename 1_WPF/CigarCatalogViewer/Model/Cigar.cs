using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CigarCatalogViewer.Model
{
    public class Cigar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public  double Price { get; set; }
        public int Rating { get; set; }

        public override string ToString()
        {
            return Company + " "+  Name + " " + Rating + " = " + Rating.ToString();
        }
    }
}
