using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ContactAppSQLLite2.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int  Id { get; set; }
        [Column("Full Name")]
        public string  Name { get; set; }
        public string  Email { get; set; }
        public string  Phone { get; set; }
    }
}
