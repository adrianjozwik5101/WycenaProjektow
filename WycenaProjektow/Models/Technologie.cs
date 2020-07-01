using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace WycenaProjektow.Models
{
    public class Technologie
    {
        public int ID { get; set; }
        public string Language { get; set; }
        public string Framework { get; set; }
        public string Type { get; set; }
    }

    public class TechnologieDBContext : DbContext
    {
        public DbSet<Technologie> Technologies { get; set; }
    }
}