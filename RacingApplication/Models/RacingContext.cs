using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RacingApplication.Models
{
    public class RacingContext:DbContext
    {
       public virtual DbSet<Driver> Driver { get; set; }
       public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Racing> Racing { get; set; }
        public virtual DbSet<Track> Track { get; set; }
    }
}