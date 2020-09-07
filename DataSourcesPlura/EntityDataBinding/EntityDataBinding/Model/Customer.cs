using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataBinding
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; }
        public string FullName { get { return string.Format("{0} {1}",FirstName,LastName); } }
    }
}
