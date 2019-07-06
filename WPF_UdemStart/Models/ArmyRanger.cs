using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ArmyRanger : GenericArmyPerson
    {
        public int Rank {get; set;}
        public string Duties { get; set;}

         ArmyRanger()
        {
            Rank = 1;
            Division = 101;
        }
    }
}
