using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WycenaProjektow.Models
{
    public class Valution
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Client { get; set; }
        public double Risk { get; set; }
    }

    public class ValutionDBContext : DbContext
    {
        public DbSet<Valution> Valutions { get; set; }
    }
}