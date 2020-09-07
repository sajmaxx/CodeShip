using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNullable
{
    public class PlayerChara
    {
        public string Name { get; set; }   
        public int? DaysSinceLastLogin {get; set;}
        public DateTime? DateOfBirth { get; set; }
        public bool? IsNewMember { get; set;}

        public PlayerChara()
        {
            DateOfBirth = null;
            DaysSinceLastLogin = null;
        }

    }
}
