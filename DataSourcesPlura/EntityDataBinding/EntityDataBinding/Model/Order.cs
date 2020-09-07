using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataBinding
{
    public class Order
    {
        public long Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public decimal ItemsTotal { get; set; }
    }
}
