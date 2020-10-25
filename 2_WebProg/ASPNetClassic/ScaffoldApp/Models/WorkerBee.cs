using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ScaffoldApp.Models
{
    public class WorkerBee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public int Age { get; set; }
        public int ZipCode { get; set; }

    }

    public class WorkerBeeDBContext : DbContext
    {
        public DbSet<WorkerBee> WorkerBees { get; set;}
    }
}