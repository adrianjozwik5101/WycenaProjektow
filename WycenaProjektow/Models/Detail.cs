using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WycenaProjektow.Models
{
    public class Detail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double PricePerHour { get; set; }
        public double Hours { get; set; }
        public double Price { get; set; }
    }

    public class DetailDBContext : DbContext
    {
        public DbSet<Detail> Details { get; set; }
    }
}